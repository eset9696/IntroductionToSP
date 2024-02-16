using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainDynamicUnload
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//1) Создаем домен приложения
			AppDomain domain = AppDomain.CreateDomain("Demo");
			//2) Загружаем длл в домен
			Assembly assembly = domain.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));
			//3) получаем модуль из которого будем вызывать функию
			Module module = assembly.GetModule("SampleLibrary.dll");
			//4) получаем класс который содержит нужный метод
			Type type = module.GetType("SampleLibrary.SampleClass");
			//5)Вынимаем метод из класса
			MethodInfo method = type.GetMethod("Print");
			//6)Вызываем метод
			method.Invoke(null, null);
		}
	}
}
