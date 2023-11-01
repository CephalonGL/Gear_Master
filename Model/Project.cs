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
        }

        public void Build(Dictionary<ParameterType, Parameter> parameters)
        {
            throw new NotImplementedException();
        }

        public void ConnectToCad(CadName cadName)
        {
            throw new NotImplementedException();
        }

        public void DisconnectDromCad()
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