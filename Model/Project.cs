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
        /// Построитель.
        /// </summary>
        private ICadBuilder _builder;

        /// <summary>
        /// Построитель.
        /// </summary>
        public ICadBuilder Builder
        {
            get => _builder;
            private set => _builder = value;
        }

        /// <summary>
        /// Конструктор с параметром целевой САПР, в которой будет выполняться построение.
        /// </summary>
        /// <param name="cadName">Название целевой САПР.</param>
        public Project(CadName cadName = CadName.AutoCad)
        {
            var cadBuilderFactory = new CadBuilderFactory();
            Builder = cadBuilderFactory.MakeBuilder(cadName);
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
        /// <param name="parameters">Параметры для построения.</param>
        public void Build(Dictionary<ParameterType, Parameter> parameters)
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
        /// <param name="cadName"></param>
        public void SelectCad(string cadName)
        {
            throw new NotImplementedException();
        }
    }
}