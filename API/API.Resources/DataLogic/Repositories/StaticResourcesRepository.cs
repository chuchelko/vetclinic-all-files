namespace API.Resources.DataLogic.Repositories
{
    using System.Xml;


    public record Service(string Name, string DoctorPhone, string DoctorName, string Price);

    public static class StaticResourcesRepository
    {

        public static List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            XmlDocument xml = new XmlDocument();
            string currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "StaticResources", "Services.xml");

            string str = File.ReadAllText(path);

            xml.LoadXml(str);
            var root = xml.DocumentElement;

            foreach(XmlNode service in root)
            {
                string name, doctorPhone, doctorName, price;

                name = service.ChildNodes[0].InnerText;
                doctorPhone = service.ChildNodes[1].InnerText;
                doctorName = service.ChildNodes[2].InnerText;
                price = service.ChildNodes[3].InnerText;
                services.Add(new Service(name, doctorPhone, doctorName, price));
            }

            return services;

        }

        public static Dictionary<string, List<string>> GetAnimalKinds()
        {
            Dictionary<string, List<string>> animalKinds = new Dictionary<string, List<string>>();

            XmlDocument xml = new XmlDocument();
            string currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "StaticResources", "AnimalKinds.xml");

            string str = File.ReadAllText(path);

            xml.LoadXml(str);

            var root = xml.DocumentElement;

            if (root == null)
                throw new NullReferenceException("AnimalKinds.xml was empty");

            foreach(XmlNode animal in root)
            {
                string? animalName = animal.Attributes?["name"]?.Value;

                if (animalName == null)
                    throw new NullReferenceException($"AnimalKinds.xml attribute 'name' of animal {animalName} was empty");

                if (!animal.HasChildNodes)
                    throw new NullReferenceException($"AnimalKinds.xml animal {animalName} has no breeds");
                
                foreach (XmlNode kind in animal.ChildNodes)
                {
                    string? breedName = kind.Attributes?["name"]?.Value;

                    if (breedName == null)
                        throw new NullReferenceException($"AnimalKinds.xml attribute 'name' of breed of animal {animalName} was empty");

                    if (!animalKinds.ContainsKey(animalName))
                        animalKinds[animalName] = new List<string>();
                    
                    animalKinds[animalName].Add(breedName);
                }
            }
            return animalKinds;
        }
    }
}
