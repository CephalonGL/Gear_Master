using System;

namespace Model
{
    /// <summary>
    /// Фабрика, создающая объекты, реализхующие интерфейс ICadBuilder.
    /// </summary>
    public class CadBuilderFactory
    {
        /// <summary>
        /// Создаёт экземпляр построителя для выбранной САПР.
        /// </summary>
        /// <param name="cadType">Название выбранной САПР.</param>
        /// <returns>Построитель для выбранной САПР.</returns>
        /// <exception cref="ArgumentException">Если осуществляется создать объект построителя, 
        /// создание которого ещё не реализовано.</exception>
        public ICadBuilder MakeBuilder(CadType cadType)
        {
            switch (cadType)
            {
                case CadType.AutoCad:
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