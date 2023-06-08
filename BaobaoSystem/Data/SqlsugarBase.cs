using SqlSugar;

namespace BaobaoSystem.Data
{
    public class SqlsugarBase
    {
        public SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=.;uid=sa;pwd=123456;database=Text",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            },
           db => {
               //5.1.3.24统一了语法和SqlSugarScope一样，老版本AOP可以写外面

               db.Aop.OnLogExecuting = (sql, pars) =>
               {
                   Console.WriteLine(sql);//输出sql,查看执行sql 性能无影响


                   //获取原生SQL推荐 5.1.4.63  性能OK
                   //UtilMethods.GetNativeSql(sql,pars)

                   //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                   //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)


               };

               //注意多租户 有几个设置几个
               //db.GetConnection(i).Aop

           });
            return db;
        }
    }
}
