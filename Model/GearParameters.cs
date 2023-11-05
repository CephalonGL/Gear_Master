namespace Model
{
    /// <summary>
    /// Парметры геометрической модели шестерни.
    /// </summary>
    public struct GearParameters
    {
        public GearParameters(double outerRadius,
                       double holeRadius,
                       double thickness,
                       int    toothCount,
                       double toothHeight)
        {
            OuterRadius = outerRadius;
            Thickness   = thickness;
            ToothCount  = toothCount;
            ToothHeight = toothHeight;
            HoleRadius  = holeRadius;
        }

        /// <summary>
        /// Внешний радиус шестерни по вершинам.
        /// </summary>
        public double OuterRadius { get;  set; }

        /// <summary>
        /// Диаметр посадочного отверстия.
        /// </summary>
        public double HoleRadius { get;  set; }

        /// <summary>
        /// Толщина шестерни.
        /// </summary>
        public double Thickness { get;  set; }

        /// <summary>
        /// Количество зубьев.
        /// </summary>
        public int ToothCount { get;  set; }

        /// <summary>
        /// Высота зуба.
        /// </summary>
        public double ToothHeight { get;  set; }
    }
}