namespace Model
{
    using System;

    /// <summary>
    /// Главный класс модели.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Конструктор с параметром целевой САПР, в которой будет выполняться построение.
        /// </summary>
        /// <param name="cadType">Название целевой САПР.</param>
        public Project(CadType cadType = CadType.AutoCad)
        {
            SelectCad(cadType);
        }

        /// <summary>
        /// Деструктор проекта.
        /// </summary>
        ~Project()
        {
            Builder.DisconnectFromCad();
        }

        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        public GearParameters Parameters { get; set; }

        /// <summary>
        /// Построитель.
        /// </summary>
        private ICadBuilder Builder { get; set; }

        /// <summary>
        /// Команда построения объекта.
        /// </summary>
        /// <param name="parameters">Параметры для построения шестерни.</param>
        public void Build(GearParameters parameters)
        {
            Builder.BuildGear(parameters);
        }

        /// <summary>
        /// Осуществляет выбор целевой САПР.
        /// </summary>
        /// <param name="cadType">Тип подключаемой САПР.</param>
        private void SelectCad(CadType cadType)
        {
            var cadBuilderFactory = new CadBuilderFactory();
            Builder = cadBuilderFactory.MakeBuilder(cadType);
            Builder.ConnectToCad();
        }
    }
}