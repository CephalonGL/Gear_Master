namespace Model
{
    /// <summary>
    /// Парметры геометрической модели шестерни.
    /// </summary>
    public struct GearParameters
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="outerDiameter">Внешний диаметр шестерни.</param>
        /// <param name="holeDiameter">Внутренний диаметр отверстия.</param>
        /// <param name="thickness">Толщина шестерни.</param>
        /// <param name="toothCount">Количество зубьев.</param>
        /// <param name="toothHeight">Высота зуба.</param>
        public GearParameters(
            Parameter outerDiameter,
            Parameter holeDiameter,
            Parameter thickness,
            Parameter toothCount,
            Parameter toothHeight)
        {
            OuterDiameter = outerDiameter;
            Thickness     = thickness;
            ToothCount    = toothCount;
            ToothHeight   = toothHeight;
            HoleDiameter  = holeDiameter;
        }

        /// <summary>
        /// Внешний радиус шестерни по вершинам.
        /// </summary>
        public Parameter OuterDiameter { get; set; }

        /// <summary>
        /// Диаметр посадочного отверстия.
        /// </summary>
        public Parameter HoleDiameter { get; set; }

        /// <summary>
        /// Толщина шестерни.
        /// </summary>
        public Parameter Thickness { get; set; }

        /// <summary>
        /// Количество зубьев.
        /// </summary>
        public Parameter ToothCount { get; set; }

        /// <summary>
        /// Высота зуба.
        /// </summary>
        public Parameter ToothHeight { get; set; }
    }
}