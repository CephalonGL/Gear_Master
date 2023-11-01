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

        Project(CadName cadName = CadName.AutoCad)
        {
            Builder = CadBuilderFactory.MakeBuilder(cadName);
        }

        public void Build(List<Parameter> parameters)
        {
            throw new NotImplementedException();
        }

        public void ConnectToCad(CadName cadName)
        {
            throw new NotImplementedException();
        }

        public void DisconnectDromCad()
        {
            throw new NotImplementedException();
        }

        public void SelectCad(string cadName)
        {
            throw new NotImplementedException();
        }
    }
}