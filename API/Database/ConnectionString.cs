namespace PA4.Database
{
    internal class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString()
        {
            // string server = "s465z7sj4pwhp7fn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            // string database = "l3ovcvtufmscce7n";
            // string port = "3306";
            // string userName = "bglsuim48xl6g8k7";
            // string password = "qx8kii47nkbpgsg0";
            string server = "wb39lt71kvkgdmw0.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "szr9onm2kszgwizi";
            string port = "3306";
            string userName = "z4xcx7h284ts9dtl";
            string password = "xdjxwlo79bwm6dgj";

            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }
    }
}