namespace BaobaoSystem.Modals
{
    public class ReturnDatas<T>
    {
        public T datas { get; set; }
        public int Code { get; set; }

        public string Msg { get; set; }
        public ReturnDatas(T datas)
        {

            this.datas = datas;

        }

        public ReturnDatas()
        {
            
        }

        public ReturnDatas<T> Success()
        {
            return new ReturnDatas<T> { Code = 1, Msg = "登陆成功" };
        }

        public ReturnDatas<T> Error() 
        {
            return new ReturnDatas<T> { Code = 0, Msg = "登录失败" };
        }

        public ReturnDatas<T> Success(T datas,int code = 1)
        { 
            return new ReturnDatas<T>(datas);
        }
           
    }
}
