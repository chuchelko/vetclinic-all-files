namespace WebApp
{
    using Grpc.Core;

    public static class CookieHelper
    {
        private const string TokenKey = "Jwt.Token";

        public static bool Authorize(HttpContext context) => context.Request.Cookies.ContainsKey(TokenKey);

        public static void Authenticate(HttpContext context, string token) => context.Response.Cookies.Append(TokenKey, token);

        public static void Logout(HttpContext context) => context.Response.Cookies.Delete(TokenKey);

        public static string? GetToken(HttpContext context) => context.Request.Cookies[TokenKey];

        public static Metadata GetHeaders(HttpContext context)
        {
            Metadata headers  = new Metadata();
            headers.Add("Authorization", "Bearer " + GetToken(context));
            return headers;
        }
    }
}
