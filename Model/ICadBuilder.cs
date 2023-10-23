using System.Collections.Generic;

namespace Model
{
    public interface ICadBuilder
    {
       void Build(List<Parameter> parameters);

       void ConnectToCad();
       
       void DisconnectFromCad();
    }
}