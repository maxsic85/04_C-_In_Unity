using UnityEngine;

namespace MAX.CODE.VARIANTNOST
{
    public delegate T Builder<out T>(string name);  //KOVAR
    public delegate void GetInfo<in T>(T item);     //KONTR
    public interface IKovar<out T>
    {
        T GetClient(string t);
    }
    public interface IKontr<in T>
    {
        void PersonInfo(T p);
    }

    public class TestKovar<T> : IKovar<T>
    {
        public T GetClient(string t)
        {
            return default;
        }
    }
    public class TestKontr<T> : IKontr<T>
    {
        public void PersonInfo(T p)
        {

        }
    }


    [ExecuteInEditMode]
    public class Kovatiantnost_Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            #region KOVARIANTNOST TEST
            //KOVARIANTNOST
            IKovar<Person> test1 = new TestKovar<Client>();
            IKovar<Person> test2 = new TestKovar<Person>();
            IKovar<Client> test3 = new TestKovar<Client>();
            //IKovar<Client> test4 = new TestKovar<Person>();*********EROR***********

            Builder<Client> _kovDelegate2 = Client.BuildClient;
            Person p = _kovDelegate2("Tom");
            p.Name.DebugLog();

            Builder<Person> _kovDelegate3 = Client.BuildClient;
            Person p2 = _kovDelegate3("Bil");
            p2.Name.DebugLog();

            Builder<Client> _kovDelegate4 = Client.BuildClient;
            Client p3 = _kovDelegate4("Bil2");
            p3.Name.DebugLog();
            /*****EROR**********
                Builder<Person> _kovDelegate6 = Client.BuildClient;
                Client p6 = _kovDelegate6("Bil2");
                p6.Name.DebugLog();
              */
            #endregion
            #region KONTRVARIANTNOST TEST
            //KONTRVARIANTNOST
            //IKontr<Person> test5 = new TestKontr<Client>();*********EROR***********
            IKontr<Person> test6 = new TestKontr<Person>();
            IKontr<Client> test7 = new TestKontr<Person>();
            IKontr<Client> test8 = new TestKontr<Client>();

            GetInfo<Person> _delegateKontr = GetPersonInfo;
            Client client = new Client { Name = "Eduardo" };
            _delegateKontr(client);

            GetInfo<Person> _delegateKontr2 = GetPersonInfo;
            Client client2 = new Client { Name = "Federik" };
            _delegateKontr2(client2);


            GetInfo<Client> _delegateKontr3 = GetPersonInfo;
            Client client3 = new Client { Name = "Dan" };
            _delegateKontr3(client3);

            GetInfo<Person> _delegateKontr4 = GetPersonInfo;
            Client client4 = new Client { Name = "Dan" };
            _delegateKontr4(client4);
            /*****EROR**********
                GetInfo<Client> _delegateKontr5 = GetPersonInfo;
                Person client5 = new Person { Name = "Dan" };
                _delegateKontr5(client5);
              */

            GetInfo<Client> _delegateKontr6 = ClientInfo;
            Client client6 = new Client { Name = "Danil" };
            _delegateKontr6(client6);
            #endregion
        }
        private static void GetPersonInfo(Person p) => (p.Name).DebugLog();
        private static void ClientInfo(Client cl) => (cl.Name).DebugLog();
    }
    public class Person
    {
        public string Name { get; set; }
    }
    public class Client : Person
    {
        public static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }
    }
}
