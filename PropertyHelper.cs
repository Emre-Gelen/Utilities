public class PropertyBase
{
    public object this[string propertyName]
    {
        get {
            PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return default;
            return propertyInfo.GetValue(this, null);
        }
        set {
            PropertyInfo propertyInfo = this.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return;
            propertyInfo.SetValue(this, value, null);
        }
    }

    public string PropertyToTry { get; set; }
}