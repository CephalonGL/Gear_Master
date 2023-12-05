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
            double outerRadius,
            double holeRadius,
            double thickness,
            double toothHeight,
            int    toothCount)
        {
            OuterRadius = outerRadius;
            HoleRadius  = holeRadius;
            Thickness   = thickness;
            ToothHeight = toothHeight;
            ToothCount  = toothCount;
        }

        /// <summary>
        /// Внешний радиус шестерни по вершинам, мм.
        /// </summary>
        public double OuterRadius { get; private set; }

        /// <summary>
        /// Радиус посадочного отверстия, мм.
        /// </summary>
        public double HoleRadius { get; private set; }

        /// <summary>
        /// Толщина шестерни, мм.
        /// </summary>
        public double Thickness { get; private set; }


        /// <summary>
        /// Высота зуба, мм.
        /// </summary>
        public double ToothHeight { get; private set; }

        /// <summary>
        /// Количество зубьев, шт.
        /// </summary>
        public int ToothCount { get; private set; }
    }
}