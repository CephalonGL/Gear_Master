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
        /// <param name="outerRadius">Внешний радиус шестерни по вершинам, мм.</param>
        /// <param name="holeRadius">Внутренний радиус отверстия, мм.</param>
        /// <param name="thickness">Толщина шестерни, мм.</param>
        /// <param name="toothCount">Количество зубьев.</param>
        /// <param name="toothHeight">Высота зуба, мм.</param>
        public GearParameters(
            Parameter outerRadius,
            Parameter holeRadius,
            Parameter thickness,
            Parameter toothCount,
            Parameter toothHeight)
        {
            OuterRadius = outerRadius;
            Thickness     = thickness;
            ToothCount    = toothCount;
            ToothHeight   = toothHeight;
            HoleRadius  = holeRadius;
        }

        /// <summary>
        /// Внешний радиус шестерни по вершинам, мм.
        /// </summary>
        public Parameter OuterRadius { get; set; }

        /// <summary>
        /// Радиус посадочного отверстия, мм.
        /// </summary>
        public Parameter HoleRadius { get; set; }

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