using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DailyAPP.WPF.HttpClients
{
    /// <summary>
    /// 调用api工具类
    /// </summary>
    public class HttpRestClient
    {
        //客户端
        private readonly RestClient Client;

        private readonly string baseUrl = "http://localhost:5226/api/";
        /// <summary>
        /// 构造方法
        /// </summary>
        public HttpRestClient()
        {
            Client = new RestClient();
        }



        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="apiRequest">请求数据</param>
        /// <returns>接收数据</returns>
        public ApiReponse Execute(ApiRequest apiRequest)
        {
            //请求方式
            var request = new RestRequest(apiRequest.Method);
            //内容类型
            request.AddHeader("Content-Type", apiRequest.ContentType);

            //如果存在请求参数-添加到请求体中
            if(apiRequest.Parameters != null)
            {
                //SerializeObject 将对象转为字符串（JSON序列化）
                request.AddParameter("param",JsonConvert.SerializeObject(apiRequest.Parameters),ParameterType.RequestBody);
            }

            //请求地址
            Client.BaseUrl = new Uri(baseUrl+ apiRequest.Route);

            //发送请求
            var response = Client.Execute(request);

            //返回结果
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //DeserializeObject 反序列化 json -> 对象
                return JsonConvert.DeserializeObject<ApiReponse>(response.Content);
            }
            else
            {
                //如果请求失败，返回错误信息
                return new ApiReponse()
                {
                    ResultCode = -99,
                    Msg = response.ErrorMessage,
                };
            }

        }
    }
}
