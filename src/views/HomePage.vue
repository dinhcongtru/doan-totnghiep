<template>
     <div class="main">
        <!-- main slide -->
        <div class="sec-slide">
            <span>
                <img src="@/assets/img/20230410_y32atDwK.webp" alt="">
            </span>
        </div>
        <!-- banner -->
        <aside>
            <div class="baner">
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban1.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">Đổi trả trong vòng 5 ngày</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban2.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">Kiểm tra hàng trước khi thanh toán</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
                <div class="baner1">
                    <span>
                       <a href="">
                         <img src="@/assets/img/ban3.webp" alt="">
                         <span></span> <span></span> <span></span> <span></span>
                       </a>
                        <div class="text-con">HỖ TRỢ SHIP cho đơn hàng từ 500K</div>
                        <button class="banner-btn">Xem chi tiết</button>
                    </span>
                </div>
            </div>
        </aside>
        <!-- sản phẩm mới -->
        <list-products 
            :labelText="labelTextProductNew"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm bán chạy -->
        <list-products 
            :labelText="labelTextProductBestSeller"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm sale -->
        <list-products 
            :labelText="labelTextProductSale"
            :isHasChildText = true
            :optionText = "optionProSale"
            :listProducts = "listNewProducts"
        />
        <!-- sản phâm áo nam -->
        <list-products 
            :labelText="labelTextProductMenshirt"
            :isHasChildText = true
            :optionText = "optionProMenshirt"
            :listProducts = "listNewProducts"
        />
        <!-- sản phẩm quần nam -->
        <list-products 
            :labelText="labelTextProductMentrousers"
            :isHasChildText = true
            :optionText = "optionProMentrousers"
            :listProducts = "listNewProducts"
        />
        <!-- phụ kiện -->
        <list-products 
            :labelText="labelTextPhukien"
            :isHasChildText = true
            :optionText = "optionProPhukien"
            :listProducts = "listNewProducts"
        />
        <!-- album -->
        <al-bum :labelText = "textAlbum"
                :listAlbum = "listAlbum"
        />
        <!-- tin tức -->
        <al-bum :labelText = "textTinTuc"
                :isHasDescribe = true
                :listAlbum = listAlbumTinTuc
        />
    </div>
</template>
<script>
import {dynamicUrlProduct} from '@/methods/index'
export default {
  name: 'HomePage',
  
  data(){
    return{
        labelTextProductNew : "Sản phẩm Mới",
        labelTextProductBestSeller: "sản phẩm bán chạy",
        labelTextProductSale : "sale",
        labelTextProductMenshirt: "áo nam",
        labelTextProductMentrousers:"quần nam",
        labelTextPhukien:"Phụ kiện",
        textAlbum:"look look",
        textTinTuc: "Tin tức",
        optionProSale : ["đồng giá 99k","Đồng giá 149k","Sale off 50%"],
        optionProMenshirt :["áo Blazer", "Áo sơ mi","Áo Tanktop","Áo polo"],
        optionProMentrousers:["quần jeans","Quần short","Quần âu","Quần Jogger","Quần kaki"],
        optionProPhukien :["dây lưng","Balo + cặp xách","Giày dép", "Mũ nam","Quần Lót"],
        listAlbum :[
            {
                urlAlbum : "#",
                imgAlbum : "alb1.jpeg",
                text : "FREEDOM | SUMMER '23 COLLECTION",
            },
            {
                urlAlbum : "#",
                imgAlbum : "alb2.webp",
                text : "ENJOY YOURSELF | NEW LOOKBOOK 2023",
            },
            {
                urlAlbum : "#",
                imgAlbum : "alb3.webp",
                text : "FROSTY | WINTER 2022 COLLECTION",
            },
            {
                urlAlbum : "#",
                imgAlbum : "alb4.webp",
                text : "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
            },
            
        ],
        listAlbumTinTuc: [
            {
                urlAlbum : "#",
                imgAlbum : "tin1.jpg",
                text : "GRAND OPENING - KRIK 132 CẦU GIẤY",
                describe : "GRAND OPENING | KRIK 132 CẦU GIẤYSự kiện khai trương cửa hàng đầu tiên mang tên KRIK tại 132 Cầu Giấy trong những ngày vừa qua đã diễn ra thành công rực rỡ và ấn tượng.KRIK xin gửi lời cảm ơn chân thành nhất tới các vị khách hàng yêu quý, gia đình và bạn bè đã tới tham dự sự kiện và ủng hộ Thương hiệu.Chúng mình sẽ cố gắng phát triển thật lớn mạnh và nâng tầm dịch vụ để làm hài lòng tất cả khách hàng cũng như khẳng định vị trí Thương hiệu tại thị trường thời trang sắp tới.------------------Hệ thống cửa hàng tại Hà Nội:- 132 Cầu Giấy- 344 Cầu Giấy- 338 Nguyễn Trãi- 23 Chùa Bộc- 209 Bạch Mai- 189 Phố Nhổn- 183 Trần CungHotline: 0982.022.969",
                urlXemthem : "#",
                textA : "Xem Thêm"
            },
            {
                urlAlbum : "#",
                imgAlbum : "tin2.webp",
                text : "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK",
                describe : "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIKBạn thân mến,9 năm là cả một chặng đường dài đối với một Thương hiệu thời trang, để có một chỗ đứng vững trãi, cùng những thành công nhất định trên thị trường, Tony4men đã phải vượt qua rất nhiều khó khăn và thách thức.Nếu như bạn đã gắn bó cùng chúng mình trong suốt thời gian qua với sự hài lòng và tin tưởng, thì KRIK hứa hẹn sẽ đem tới cho bạn nhiều điều bất ngờ về sự mới mẻ, bùng nổ sáng tạo, và đặc biệt là những trải nghiệm tuyệt vời về sản phẩm cũng như chất lượng dịch vụ trong thời gian tới.Một phiên bản mới với sự hoàn hảo về mọi khía cạnh đến từ KRIK. Không đơn giản chỉ là thương hiệu thời trang, KRIK còn mang tầm nhìn và sứ mệnh mong muốn trở thành người bạn đồng hành của phái mạnh trong bất cứ hoàn cảnh nào.Cùng chúng mình đón chờ và trải nghiệm những điều tuyệt vời đang nằm ở phía trước nhé ^^",
                urlXemthem : "#",
                textA : "Xem Thêm"
            },
            {
                urlAlbum : "#",
                imgAlbum : "tin3.webp",
                text : "Cách thức đặt hàng",
                describe : "Cách thức đặt hàngĐặt hàng qua Hotline: Gọi trực tiếp đến sđt: 0982.022.969 để được nhân viên tư vấn hỗ trợ nhanh nhất về sản phẩm và dịch vụ.Đặt hàng trên FB: Gửi ảnh hoặc mã sp mà mình quan tâm đến Page KRIK (m.me/krik.vn). Nhân viên tư vấn sẽ trả lời nhanh nhất khi có thể. Liên hệ trực tiếp số hotline: 0982.022.969 để được hỗ trợ nhanh nhất.Đặt hàng trên Web:B1: Click vào sản phẩm muốn đặt hàngB2: Chọn màu sắc, size và số lượng muốn đặt rồi Click [Mua Ngay]B3: Click vào [ Tiến hành đặt hàng ] để chuyển sang giao diện điền thông tin giao hàng hoặc có thể click vào [ Xem chi tiết giỏ hàng ] để xem lại giỏ hàng của mình.B4: Điền thông tin vào form đặt hàng: Họ tên, số điện thoại, email, địa chỉB5: Chọn phương thức thanh toán: COD (thanh toán tại nhà)B6: Hoàn tất đơn hàngKRIK sẽ xác nhận đơn hàng bằng cách gọi điện. Vui lòng nghe máy để chúng tôi có thể lên đơn thành công giúp bạn.",
                urlXemthem : "#",
                textA : "Xem Thêm"
            },
            {
                urlAlbum : "#",
                imgAlbum : "tin4.webp",
                text : "Chính sách thành viên",
                describe : "Chính sách thành viênMEMBER CARD: Tổng giá trị hóa đơn đã mua từ 0-3tr được tích 3% trên tổng giá trị hóa đơn.VIP CARD: Tổng giá trị hóa đơn đã mua từ 3-6tr được tích 5% trên tổng giá trị hóa đơnSUPERVIP CARD: Tổng giá trị hóa đơn đã mua >6tr được tích 8% trên tổng giá trị hóa đơn.⇒ Khách hàng mua hàng (tại cửa hàng) trong tuần sinh nhật ( trước và sau ngày sinh nhật 3 ngày ) được giảm 10% trên tổng hóa đơn.",
                urlXemthem : "#",
                textA : "Xem Thêm"
            }
        ],
        listNewProducts : [
            {
                hrefPro : dynamicUrlProduct('name default'),
                category : "Áo Nam",
                imgProMain : "sp2.webp",
                listcolors : [
                    {
                        selected : false,
                        name : "Be",
                        image : "sp3.webp"
                    },
                    {
                        selected : false,
                        name : "Trắng",
                        image : "sp4.jpeg"
                    },
                ],                 
                name : "name default",
                price : 0,
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : dynamicUrlProduct('name default'),
                category : "Áo Nam",
                imgProMain : "sp2.webp",
                listcolors : [
                    {
                        selected : false,
                        name : "Be",
                        image : "sp3.webp"
                    },
                    {
                        selected : false,
                        name : "Trắng",
                        image : "sp4.jpeg"
                    },
                ],                  
                name : "name default",
                price : 0,
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : dynamicUrlProduct('name default'),
                category : "Áo Nam",
                imgProMain : "sp2.webp",
                listcolors : [
                    {
                        selected : false,
                        name : "Be",
                        image : "sp3.webp"
                    },
                    {
                        selected : false,
                        name : "Trắng",
                        image : "sp4.jpeg"
                    },
                ],                  
                name : "name default",
                price : 0,
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
            {
                hrefPro : dynamicUrlProduct('name default'),
                category : "Áo Nam",
                imgProMain : "sp2.webp",
                listcolors : [
                    {
                        selected : false,
                        name : "Be",
                        image : "sp3.webp"
                    },
                    {
                        selected : false,
                        name : "Trắng",
                        image : "sp4.jpeg"
                    },
                ],                  
                name : "name default",
                price : 0,
                textBuy : "Mua nhanh",
                textDes : "Xem Chi Tiết"
            },
        ]
    }

  }
}
</script>
<style scoped>
/* .innerHomeStore{
    width: 100%;
    height: 317px;
    padding: 30px 0;
}
.innerHomeStore > .imgeStore img{
    height: 317px;
} */
.main{
    margin-bottom: 100px;
}
.sec-slide{
    width: 100%;
   
}
.sec-slide > span > img{
    width: 100%;
}
.baner{
    display: flex;
    align-items: center;
    overflow: hidden;
    width: 100%;
    justify-content: center;
    margin: 50px 0;
    padding: 0 64px;
}
.baner1{
    width: 31%;
    padding: 0 15px;
}
.baner > .baner1 > a{
    position: relative;
}
.baner1 > span{
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 8% 0 0;
}
.baner1 > span > a{
    overflow: hidden;
    position: relative;
}
.baner1 > span > a span{
    position: absolute;
    background-color: rgba(255,255,255,.7);
    display: block;
    margin: 12px;
    transition: all 0.5s linear;
   
}
.baner1 > span > a span:nth-child(2){
    top: 0;
    left: 0;
    width: 0;
    height: 2px;
}
.baner1 > span > a span:nth-child(3){
    top: 0;
    right: 0;
    width: 2px;
    height: 0;
}
.baner1 > span > a span:nth-child(4){
    bottom: 0;
    right: 0;
    width: 0;
    height: 2px;
}
.baner1 > span > a span:nth-child(5){
    bottom: 0;
    left: 0;
    width: 2px;
    height: 0;
}
.baner1 > span > a:hover span:nth-child(odd){
    height: calc(100% - 24px);
}
.baner1 > span > a:hover span:nth-child(even){
    width: calc(100% - 24px);
}
.baner1 span a img{
 width: 100%;
 border-radius: 2px;
 opacity: 1;
transition: .3s;
}
.baner1 span a img{
   
    /* transform: scale(0,1); */
    border-left-color: transparent;
    border-right-color: transparent;
    top: 10px;
    bottom: 10px;
    left: 10px;
    right: 10px;
}
.text-con {
    margin: 7px 0;
    font-size: 14px;
}
a {
    transition: opacity .15s linear,color .15s linear,background .15s linear;
}
.banner-btn{
    border: 1px solid;
    padding: 5px 10px;
    display: inline-block;
    font-size: 13px;
    text-transform: uppercase;
}
.banner-btn:hover{
    background: #000;
    color: #fff;
    cursor: pointer;
}
</style>