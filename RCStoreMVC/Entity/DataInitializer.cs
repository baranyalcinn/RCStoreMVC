using RCStoreMVC.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace RCStoreMVC.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            var kategoriler = new List<Category>()
            {
                new Category(){ CategoryName ="Propeller", Description="Pervaneler" },
                new Category(){ CategoryName ="Charger", Description="Şarj Cihazları" },
                new Category(){ CategoryName ="LandingGear", Description="İniş Takımları" },
                new Category(){ CategoryName ="ModelPlane" , Description="Model Uçaklar"},
                new Category(){ CategoryName ="PetrolEngine", Description="Benzinli Motorlar" },
                new Category(){ CategoryName ="RadioController", Description="Radyo Kumandalar" },
                new Category(){ CategoryName ="SpeedControlUnit", Description="Hız Kontrol Üniteleri" },
                new Category(){ CategoryName ="Battery" , Description="Bataryalar"},
                new Category(){ CategoryName ="dcMotor" , Description="Elektrik Motorları"},
                new Category(){ CategoryName ="Cable" , Description="Bağlantı Kabloları"}

            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();


            var urunler = new List<Product>() {
            
                new Product(){Marka="3 Blade Propeller 6x45 Black (2 CCW 2CW) 4 ADET", Fiyat= 124, CategoryId=1, Image = "3 Blade Propeller 6x45 Black (2 CCW 2CW) 4 ADET.jpg"},
                new Product(){Marka="23X3D Ahşap Benzinli Uçak Pervanesi 50-60cc", Fiyat= 255, CategoryId=1,IsHome=true, Image="23X3D Ahşap Benzinli Uçak Pervanesi 50-60cc.jpg"},
                new Product(){Marka="FMS-12 BLADE-PROPELLER", Fiyat= 80, CategoryId=1,Image="fms-12-blade-propeller.jpg"},

                new Product(){Marka="HOTA P6 2x300w CHARGER", Fiyat= 4120, CategoryId=2,IsHome=true,Image="HOTA P6 2x300w CHARGER.jpg"},
                new Product(){Marka="RADIO LINK CB86-PLUS CHARGER", Fiyat= 2648, CategoryId=2,Image="RADIO-LINK-CB86-PLUS-CHARGER.jpeg"},

                new Product(){Marka="İNİŞ TAKIMI SETİ (1.5KG - 2KG UÇAKLAR İÇİN)", Fiyat= 156, CategoryId=3,IsHome=true,Image="İNİŞ TAKIMI SETİ (1.5KG - 2KG UÇAKLAR İÇİN).jpg"},
                new Product(){Marka="Du-Bro HAVALI LASTİK TEKER 114 MM 4,50'", Fiyat= 64, CategoryId=3,Image="Du-Bro HAVALI LASTİK TEKER 114 MM 4,50''.jpg"},
                new Product(){Marka="4MM TEKERLEK STOPPER", Fiyat= 40, CategoryId=3,Image="4MM TEKERLEK STOPPER.jpg"},

                new Product(){Marka="DOLPHİN JET 71' 1,85 M", Fiyat= 38632, CategoryId=4,IsHome=true,Image="DOLPHİN JET 71'' 1,85 M.jpg"},
                new Product(){Marka="FMS PA-18 SUPER CUB PNP 1700MM", Fiyat= 9473, CategoryId=4,Image="FMS PA-18 SUPER CUB PNP 1700MM.jpg"},
                new Product(){Marka="THK ATA PLANÖR MODEL UÇAĞI", Fiyat= 38, CategoryId=4,Image="THK-ATA-PLANÖR-MODEL-UÇAĞI.jpeg"},

                new Product(){Marka="RCGF STINGER 35-RE", Fiyat= 17351, CategoryId=5,IsHome=true,Image="RCGF-STINGER-35-RE.jpeg"},
                new Product(){Marka="RCGF STINGER 70 CC TWIN", Fiyat= 32146, CategoryId=5,Image="RCGF-STINGER-70-CC-TWIN.jpeg"},

                new Product(){Marka="FLYSKY FS-İ4X 4 KANAL KUMANDA", Fiyat= 5140, CategoryId=6,IsHome=true,Image="FLYSKY FS-İ4X 4 KANAL KUMANDA.jpg"},
                new Product(){Marka="RADIOLINK T8FB", Fiyat= 2461, CategoryId=6,Image="RADIOLINK-T8FB.jpeg"},

                new Product(){Marka="18A ESC Emax ESC", Fiyat= 486, CategoryId=7,IsHome=true,Image="18A ESC Emax ESC.jpg"},
                new Product(){Marka="40A Fırçasız ESC, 3A BEC", Fiyat= 1879, CategoryId=7,Image="40A Fırçasız ESC, 3A BEC.jpg"},
                new Product(){Marka="ESC (DRON, HELI, AIR) 120A HV 12S 5-8A BEC", Fiyat= 3699, CategoryId=7,Image="ESC (DRON, HELI, AIR) 120A HV 12S 5-8A BEC.jpg"},

                new Product(){Marka="6S 65C 3300 MAH LEOPARD BATARYA", Fiyat= 2100, CategoryId=8,IsHome=true,Image="6S 65C 3300 MAH LEOPARD BATARYA.jpg"},
                new Product(){Marka="5S 45C 3300 MAH LEOPARD BATARYA", Fiyat= 1000, CategoryId=8,Image="5S 45C 3300 MAH LEOPARD BATARYA.jpg"},
                new Product(){Marka="EMAX BATARYA 4S 2300 MAH", Fiyat= 500, CategoryId=8,Image="EMAX BATARYA 4S 2300 MAH.jpg"},

                new Product(){Marka="SunnySky R2207 FPV Motor 1800KV CCW", Fiyat= 2286, CategoryId=9,IsHome=true,Image="SunnySky-R2207-FPV-Motor-1800KV-CCW.jpeg"},
                new Product(){Marka="SunnySky X2826 V3 Brushless Motor 880KV", Fiyat= 1300, CategoryId=9,Image="SunnySky-X2826-V3-Brushless-Motor-880KV.jpeg"},
                new Product(){Marka="Elektirkli Güç Seti 20CC 26CC", Fiyat= 600, CategoryId=9,Image="Elektirkli Güç Seti 20CC 26CC.jpg"},

                new Product(){Marka="10CM JR SERVO UZATMA KABLOSU", Fiyat= 100, CategoryId=10,IsHome=true,Image="10CM JR SERVO UZATMA KABLOSU.jpg"},
                new Product(){Marka="PRLL T KNNKTR", Fiyat= 50, CategoryId=10,Image="PRLL-T-KNNKTR.jpeg"},
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }



            var links = new List<Links>()
            {

                new Links(){Url="https://ideacdn.net/idea/fo/47/myassets/products/653/img-20210219-115611.jpg?revision=1697143329"},
                new Links(){Url="https://ideacdn.net/idea/fo/47/myassets/products/872/12-blade-propeller.jpg?revision=1697143329"},
                new Links(){Url="https://www.thkmodelucak.com/urun/3-blade-propeller-6x45-black-2-ccw-2cw-4-adet-1901"},
                new Links(){Url="https://ideacdn.net/idea/fo/47/myassets/products/708/1.PNG?revision=1697143329"},
                new Links(){Url="https://ideacdn.net/idea/fo/47/myassets/products/707/70cc-twin-3.jpg?revision=1697143329"},
                new Links(){Url="https://www.thkmodelucak.com/urun/flysky-fs-i4x-4-kanal-kumanda"},
                new Links(){Url="https://ideacdn.net/idea/fo/47/myassets/products/773/m.jpg?revision=1697143329"},
                new Links(){Url="https://www.thkmodelucak.com/urun/fms-pa-18-super-cub-pnp-1700mm"},
                new Links(){Url="https://www.thkmodelucak.com/urun/radio-link-cb86-plus-sarj-aleti"},
                new Links(){Url="https://www.thkmodelucak.com/urun/hota-p6-2x300w-charger"},
                new Links(){Url="https://www.thkmodelucak.com/urun/havali-lastik-teker-114-mm-4-50-1908"},
                new Links(){Url="https://www.thkmodelucak.com/urun/inis-takimi-seti-1-5kg-2kg-ucaklar-icin"},
                new Links(){Url="https://www.thkmodelucak.com/urun/thk-ata-planor-model-ucagi"},
                new Links(){Url="https://www.thkmodelucak.com/urun/pilor-rc-dolphin-jet-71-1-85-m-kirmizi"},
                new Links(){Url="https://www.thkmodelucak.com/urun/18a-esc-budget"},
                new Links(){Url="https://www.thkmodelucak.com/urun/esc-dron-heli-air-120a-hv-12s-5-8a-bec"},
                new Links(){Url="https://www.thkmodelucak.com/urun/40a-esc-fms"},
                new Links(){Url="https://www.thkmodelucak.com/urun/6s-65c-3300-mah-leopard-batarya"},
                new Links(){Url="https://www.thkmodelucak.com/urun/5s-45c-3300-mah-leopard-batarya"},
                new Links(){Url="https://www.thkmodelucak.com/urun/emax-batarya-4s-2300-mah"},
                new Links(){Url="https://www.thkmodelucak.com/urun/sunnysky-r2207-fpv-motor-1800kv-ccw-1891"},
                new Links(){Url="https://www.thkmodelucak.com/urun/sunnysky-x2826-v3-brushless-motor-880kv-1894"},
                new Links(){Url="https://www.thkmodelucak.com/urun/pilot-rc-elektirkli-guc-seti-20cc-26cc-ucaklar-icin"},
                new Links(){Url="https://www.thkmodelucak.com/urun/prll-t-knnktr"},
                new Links(){Url="https://www.thkmodelucak.com/urun/jr-servo-kablosu-2-tarafi-disi-10-cm"},
                new Links(){Url="https://blog.stackademic.com/accelerating-development-with-nestjs-1b5567b1c537"}
          
            };

            foreach (var link in links)
            {
                context.Links.Add(link);
            }




            context.SaveChanges();

            

            base.Seed(context);
        }
    }

}