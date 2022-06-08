using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ImageViewer.Common
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression) => this.RaisePropertyChanged(ExtractPropertyName<T>(propertyExpression));
        
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));
            if (!(propertyExpression.Body is MemberExpression body))
                throw new ArgumentException( nameof(body));
            PropertyInfo member = body.Member as PropertyInfo;
            if (member == null)
                throw new ArgumentException( nameof(member));
            return body.Member.Name;
        }
    }
}
