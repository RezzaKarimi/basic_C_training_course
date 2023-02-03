using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mo_Shop
{
    internal class mobile
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int number { get; set; }

        db db = new db();

        public void create(mobile mobile)
        {
            var q = from i in db.mob where i.name == mobile.name select i.id;
            if (q.Count() == 1)
            {
                MessageBox.Show("این محصول در انبار موجود است");
               
            }
            else
            {
                if (mobile.name !=null && mobile.price !=null && mobile.number !=null && mobile.price>0 && mobile.number>0)
                {
                    db.mob.Add(mobile);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("اطلاعات را به درستی وارد کنید");
                    return;
                }
                
               
            }
            
        }

        public mobile read(int id)
        {
            return (from i in db.mob where i.id == id select i).Single();
        }

        public List<mobile> read(string name)
        {
            var q = from i in db.mob where i.name.Contains(name) select i;
            List<mobile> list = q.ToList();
            return list;

        }

        
        public void updat(mobile mobile , int id)
        {
            var q = from i in db.mob where i.id == id select i;
            if(q.Count() == 1)
            {
                mobile m = new mobile();
                m = q.Single();
                m.name = mobile.name;
                m.price = mobile.price;
                m.number = mobile.number;
                db.SaveChanges();
                
            }
            

        }
        public void delete(mobile mobile , int id)
        {
            /// check
            var q = from i in db.mob where i.id == id select i;
            if(q.Count() == 1)
            {
                mobile mob = new mobile();
                mob = q.Single();
                mob.id = mobile.id;
                mob.name = mobile.name;
                mob.price = mobile.price;
                mob.number = mobile.number;

               delete d = new delete();
               d.d.Add(mob); 
               d.SaveChanges();

               //db.mob.Remove(mob);
               //db.SaveChanges();

            }
        }

    }
}
