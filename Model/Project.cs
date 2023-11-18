using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Главный класс модели.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Параметры шестерни.
        /// </summary>
        public GearParameters Parameters { get; set;}
        
        /// <summary>
        /// Построитель.
        /// </summary>
        public ICadBuilder Builder { get; private set; }

        /// <summary>
        /// Конструктор с параметром целевой САПР, в которой будет выполняться построение.
        /// </summary>
        /// <param name="cadType">Название целевой САПР.</param>
        public Project(CadType cadType = CadType.AutoCad)
        {
            var cadBuilderFactory = new CadBuilderFactory();
            Builder = cadBuilderFactory.MakeBuilder(cadType);
            ConnectToCad();
        }

        /// <summary>
        /// Деструктор проекта.
        /// </summary>
        ~Project()
        {
            DisconnectFromCad();
        }

        /// <summary>
        /// Команда построения объекта.
        /// </summary>
        public void Build(GearParameters parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет подключение к целевой САПР.
        /// </summary>
        public void ConnectToCad()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет отключение от целевой САПР.
        /// </summary>
        public void DisconnectFromCad()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Осуществляет выбор целевой САПР.
        /// </summary>
        /// <param name="cadType"></param>
        public void SelectCad(CadType cadType)
        {
            var cadBuilderFactory = new CadBuilderFactory();
            Builder = cadBuilderFactory.MakeBuilder(cadType);
        }
    }
}