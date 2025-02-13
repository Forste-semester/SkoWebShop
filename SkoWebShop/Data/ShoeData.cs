using SkoWebShop.Models;

namespace SkoWebShop.Data
{
    public static class ShoeData
    {


        private static readonly Dictionary<int, Shoe> shoes = new Dictionary<int, Shoe>()
{
    {1, new Shoe("Nike Air Max", 45, ShoeType.Sneaker, 1400, "https://www.sneakerfiles.com/wp-content/uploads/2022/10/nike-air-max-90-gore-tex-anthracite-pure-platinum-dj9779-004-release-date-info.jpeg")},
    {2, new Shoe("Adidas Ultraboost", 42, ShoeType.Running_Shoe, 1600, "https://assets.adidas.com/images/w_600,f_auto,q_auto/ultraboost-22-shoes.jpg")},
    {3, new Shoe("Crocs Classic", 38, ShoeType.Croc, 600, "https://www.purebrandsuk.com/images/crocs-classic-lined-black-black-ux3-203591-060-unisex-shoes-clogs-p2789-12757_medium.jpg")},
    {4, new Shoe("Puma RS-X", 41, ShoeType.Sneaker, 1100, "https://images.puma.com/image/f_auto,q_auto/rs-x-reinvention.jpg")},
    {5, new Shoe("New Balance 574", 42, ShoeType.Sneaker, 900, "https://nb.scene7.com/is/image/NewBalance/574-core.jpg")},
    {6, new Shoe("Vans Old Skool", 40, ShoeType.Sneaker, 800, "https://images.vans.com/is/image/Vans/old-skool-shoe.jpg")},
    {7, new Shoe("Converse Chuck Taylor", 42, ShoeType.Sneaker, 750, "https://images.converse.com/is/image/Converse/chuck-taylor-all-star.jpg")},
    {8, new Shoe("Reebok Classic", 43, ShoeType.Sneaker, 850, "https://assets.reebok.com/images/w_600,f_auto,q_auto/classic-leather-shoes.jpg")},
    {9, new Shoe("Fila Disruptor", 39, ShoeType.Sneaker, 950, "https://images.fila.com/is/image/Fila/disruptor-ii.jpg")},
    {10, new Shoe("ASICS Gel-Kayano", 44, ShoeType.Running_Shoe, 1300, "https://asics.scene7.com/is/image/Asics/gel-kayano-27.jpg")},
    {11, new Shoe("Balenciaga Triple S", 45, ShoeType.Sneaker, 5000, "https://balenciaga.dam.kering.com/m/7b0b8d8d4e3c4b8e/triple-s-sneaker.jpg")},
    {12, new Shoe("Yeezy Boost 350", 42, ShoeType.Sneaker, 3000, "https://assets.adidas.com/images/w_600,f_auto,q_auto/yeezy-boost-350.jpg")},
    {13, new Shoe("Timberland Boots", 43, ShoeType.Sandals, 1800, "https://images.timberland.com/is/image/Timberland/prod-6-inch-premium-boot.jpg")},
    {14, new Shoe("Dr. Martens 1460", 41, ShoeType.Sandals, 1700, "https://www.drmartens.com/images/1460-boot.jpg")},
    {15, new Shoe("Salomon XT-6", 44, ShoeType.Running_Shoe, 1400, "https://images.salomon.com/is/image/Salomon/xt-6.jpg")},
    {16, new Shoe("Hoka One One Clifton", 42, ShoeType.Running_Shoe, 1200, "https://cdn.hoka.com/is/image/Hoka/clifton-7.jpg")},
    {17, new Shoe("Saucony Endorphin Pro", 43, ShoeType.Running_Shoe, 1500, "https://saucony-cdn.endclothing.com/images/endorphin-pro.jpg")},
    {18, new Shoe("Mizuno Wave Rider", 41, ShoeType.Running_Shoe, 1100, "https://mizuno.scene7.com/is/image/Mizuno/wave-rider-24.jpg")},
    {19, new Shoe("Birkenstock Arizona", 40, ShoeType.Sandals, 700, "https://cdn.birkenstock.com/images/arizona-sandal.jpg")},
    {20, new Shoe("Teva Hurricane XLT2", 41, ShoeType.Sandals, 800, "https://images.tevacdn.com/is/image/Teva/hurricane-xlt2.jpg")}
};




        public static Dictionary<int, Shoe> GetAll {  get { return shoes; } }


    }
}
