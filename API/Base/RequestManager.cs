using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;
using Base.Abstract;
using Newtonsoft.Json;
namespace Base
{
   public  class RequestManager
    {
        static RequestManager inst;

        List<BaseProcess> operations = new List<BaseProcess>();

        public static RequestManager Instance {
            get {

                if (inst == null)
                    inst = new RequestManager();

                return inst;
            }
        
        }

        RequestManager() {

            Assembly asm = Assembly.GetExecutingAssembly();
            string loc = asm.CodeBase;


            UriBuilder uri = new UriBuilder(loc);

            string path = Uri.UnescapeDataString(uri.Path);

            string asmPath = Path.GetDirectoryName(path);


            /*
            * Load the dlls in order to expose in the AppDomain.CurrentDomain
            * */

            Assembly.LoadFrom(Path.Combine(asmPath, "Auth.dll"));
            Assembly.LoadFrom(Path.Combine(asmPath, "Transaction.dll"));


            Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(x => x.IsSubclassOf(typeof(BaseProcess))).ToArray();


            foreach(Type type in types){

                operations.Add((BaseProcess)Activator.CreateInstance(type));
            
            }

        }

        public BaseResponseMessage OnProcessRequest(string message) {

            string tranCode = JsonConvert.DeserializeObject<BaseMessage>(message).trancode;

            var ops = operations.Where(myType => myType.trancode == tranCode).FirstOrDefault();

            Type messageType = ops.messageType;

            ops._message = (BaseMessage)JsonConvert.DeserializeObject(message, messageType);


            ops.DoProcess();



            return ops._responseMessage;

        
        }

    }
}
