using System;

namespace Model
{
    public class CadBuilderFactory
    {
        public ICadBuilder MakeBuilder(CadName cadName)
        {
            switch (cadName)
            {
                case CadName.AutoCad:
                {
                    return new AutoCadBuilder();
                }
                default:
                {
                    throw new ArgumentException("Ошибка! Неизвестный тип САПР.");
                }
            }
        }
    }
}