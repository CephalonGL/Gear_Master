namespace Model
{
    /// <summary>
    /// Парметры геометрической модели шестерни.
    /// Указаны в системе СИ.
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
        /// Внешний радиус шестерни по вершинам, мм.
        /// </summary>
        public Parameter OuterDiameter { get; set; }

        /// <summary>
        /// Диаметр посадочного отверстия, мм.
        /// </summary>
        public Parameter HoleDiameter { get; set; }

        /// <summary>
        /// Толщина шестерни, мм.
        /// </summary>
        public Parameter Thickness { get; set; }

        /// <summary>
        /// Количество зубьев, шт.
        /// </summary>
        public Parameter ToothCount { get; set; }

        /// <summary>
        /// Высота зуба, мм.
        /// </summary>
        public Parameter ToothHeight { get; set; }
    }
}