using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal _MessageDal;

        public MessageManager(IMessageDal MessageDal)
        {
            _MessageDal = MessageDal;
        }

        public void TDelete(Message t)
        {
            _MessageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _MessageDal.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _MessageDal.GetList();
        }

        public void TInsert(Message t)
        {
            _MessageDal.Insert(t);
        }

        public void TUpdate(Message t)
        {
            _MessageDal.Update(t);
        }
    }
}
