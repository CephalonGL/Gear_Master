namespace Model
{
    public class Parameter
    {
        Parameter(ParameterType parameterType, double maxValue, double minValue, string name)
        {
            ParameterType = parameterType;
            MaxValue      = maxValue;
            MinValue      = minValue;
            Name          = name;
        }
        
        public double MaxValue { get; private set; }
        
        public double MinValue { get; private set; }
        
        public string Name { get; private set; }
        
        public double Value { get; set; }
        
        public ParameterType ParameterType { get; private set; }
    }
}