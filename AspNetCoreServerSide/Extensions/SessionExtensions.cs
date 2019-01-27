namespace AspNetCoreServerSide.Extensions
{
    public static class SessionExtensions
    {
        //public static void SetSessionData(this ISession session, SessionKey key, object data)
        //    => session.SetString(key.ToString(), JsonConvert.SerializeObject(data));

        //public static T GetSessionData<T>(this ISession session, SessionKey key)
        //{
        //    var value = session.GetString(key.ToString());

        //    return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        //}

        //public static T GetSessionDataAndClear<T>(this ISession session, SessionKey key)
        //{
        //    var value = session.GetString(key.ToString());
        //    var data = value == null ? default : JsonConvert.DeserializeObject<T>(value);

        //    session.Remove(key.ToString());

        //    return data;
        //}
    }
}
