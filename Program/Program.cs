using library;
using System.Reflection;
using System.Text;

StringBuilder outputText = new(1000);

void AddToOutput(string text) =>
    outputText.Append($"{Environment.NewLine}{text}");

Assembly theAssembly = Assembly.Load(new AssemblyName("library"));

AddToOutput($"Assembly: {theAssembly.FullName}");
AddToOutput("Defined Types:");

foreach (Type definedType in theAssembly.ExportedTypes)
{
    if (definedType.GetTypeInfo().IsClass)
    {
        AddToOutput($"{Environment.NewLine}class {definedType.Name} : {definedType.BaseType}");
        
        IEnumerable<MyAttribute> attributes = definedType.GetTypeInfo().GetCustomAttributes().OfType<MyAttribute>().ToArray();
        if (attributes.Count() > 0)
        {
            foreach (MyAttribute attribute in attributes)
            {
                AddToOutput($"{Environment.NewLine}Comment: {attribute.Comment}");
            }
        }
        
        AddToOutput("Methods:");
        foreach (MethodInfo method in definedType.GetMethods())
        {
            string modificator = "";
            if (method.IsStatic) modificator += "static ";
            if (method.IsVirtual) modificator += "virtual ";
 
            AddToOutput($"{modificator}{method.ReturnType.Name} {method.Name} ()");
        }
    }
}

System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(String));
FileStream file = File.Create("AssemblyOverview.xml");
writer.Serialize(file, outputText.ToString());  
file.Close();  


