namespace Events
{
    public class Observer
    {
        public static void Subscribe<T>(System.Action<object, T> action)
        {
            EventHelper<T>.action += action;
        }

        public static void Unsubscribe<T>(System.Action<object, T> action)
        {
            EventHelper<T>.action -= action;
        }

        public static void Post<T>(object sender, T eventData)
        {
            EventHelper<T>.Post(sender, eventData);
        }

        private class EventHelper<T>
        {
            public static event System.Action<object, T> action;

            public static void Post(object sender, T eventData)
            {
                action?.Invoke(sender, eventData);
            }
        }
    }
}