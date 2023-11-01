using System;
using System.Collections.Generic;

namespace Model
{
    public class Project
    {
        private ICadBuilder _builder;

        public ICadBuilder Builder
        {
            get => _builder; 
            private set => _builder = value;
        }

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

        public void ConnectToCad(CadName cadName)
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

        public void SelectCad(string cadName)
        {
            throw new NotImplementedException();
        }
    }
}