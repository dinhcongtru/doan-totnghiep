<template>
     <footer>
        <div class="innerHomeStore">
            <span class="imgeStore">
                <img style="width: 100%;" src="../assets//img/imgStore.webp" alt="">
            </span>
        </div>
        <span>
            <div class="foot-top">
            <div class="phone">
                <div class="text-phone">GỌI MUA HÀNG ( 08:30-22:00 )</div>
                <div class="mert-phone">
                    <i class="fa-sharp fa-solid fa-phone-volume"></i>
                    <div>0964189895</div>
                </div>
                <div class="mota">Tất cả các ngày trong tuần</div>
            </div>
            <div class="phone">
                <div class="text-phone">GÓP Ý, KHIẾU NẠI ( 08:30-22:00 )</div>
                <div class="mert-phone">
                    <i class="fa-sharp fa-solid fa-phone-volume"></i>
                    <div>0964189895</div>
                </div>
                <div class="mota">Tất cả các ngày trong tuần</div>
            </div>
            <div class="phone">
                <div class="text-phone">ĐĂNG KÝ NHẬN THÔNG TIN MỚI</div>
                <div class="mert-phone">
                    <div class="inpSpan">
                        <input type="text" placeholder="Nhập email của bạn..."/>
                    </div>
                    <span>
                        <button>ĐĂNG KÝ</button>
                    </span>
                </div>
            </div>
            <div class="phone">
                <div class="text-phone">GÓP Ý, KHIẾU NẠI ( 08:30-22:00 )</div>
                <div class="mert-icon">
                  <i class="fa-brands fa-facebook"></i>
                  <i class="fa-brands fa-instagram"></i>
                  <i class="fa-brands fa-telegram"></i>
                  <i class="fa-brands fa-skype"></i>
                </div>
            </div>
        </div>
        </span>
       
        <div class="foot-bottom">
            <div class="row-rule">
                <h4 class="footer-title">
                    CHÍNH SÁCH VÀ QUY ĐỊNH
                </h4>
                <div class="footercontent">Cách thức đặt hàng</div>
                <div class="footercontent">Chính sách thành viên</div>
                <div class="footercontent">Chính sách giao hàng</div>
                <div class="footercontent">Quy định đổi trả</div>
                <div class="footercontent">Hình thức thanh toán</div>
                <div class="footercontent">Chính sách bảo mật</div>
                <div class="footercontent">Chính sách xử lý khiêu nại</div>
                <div class="footercontent">Chính sách kiểm hàng</div>
            </div>
            <div class="row-rule">
                <h4 class="footer-title">
                    HỆ THỐNG CỬA HÀNG
                </h4>
                <div class="footercontent">►25C Đại La</div>
                <div class="footercontent">►344 Cầu Giấy</div>
                <div class="footercontent">►132 Cầu Giấy</div>
                <div class="footercontent">►280 - 282 Nguyễn Trãi</div>
                <div class="footercontent">►167 Chùa Bộc</div>
                <div class="footercontent">►307H Bạch Mai</div>
                <div class="footercontent">►23 Chùa Bộc</div>
                <div class="footercontent">►189 Phố Nhổn</div>
            </div>
            <div class="row-rule">
                <h4 class="footer-title">
                    VỀ CHÚNG TÔI
                </h4>
                <div class="footercontent indam font-14">Công ty TNHH KRIK Việt Nam</div>
                <p class="footercontent font-14"><strong class="indam font-14">Địa chỉ </strong>:Số 344 Cầu Giấy, Phường Dịch Vọng, Quận Cầu Giấy, Thành phố Hà Nội</p>
                <p class="footercontent font-14"><strong class="indam font-14">Mã số doanh nghiệp </strong>:0108901419 do Sở kế hoạch và đầu tư thành phố Hà Nội cấp ngày 17/09/2019</p>
                <p class="footercontent font-14"><strong class="indam font-14">Điện thoại </strong>:0982.022.969</p>
                <p class="footercontent font-14"><strong class="indam font-14">Email </strong>:nhansu@krik.vn</p>
                <p>
                    <a href="http://online.gov.vn/Home/WebDetails/92526">
                        <img src="../assets/img/bocongthuong.png" alt="">
                    </a>
                </p>
            </div>
            <div class="row-rule">
                <h4 class="footer-title">
                    FANPAGE CHÚNG TÔI
                </h4>
                <div class="footercontent">
                    <img style="width:100%" src="../assets/img/fac.png" alt="">
                </div>
                
            </div>
        </div>
     </footer>
</template>
<script>
export default{
    name: 'TheFooter',
}
</script>
<style scoped>
.innerHomeStore{
    width: 100%;
    height: 317px;
    margin-bottom: 50px;
}
.innerHomeStore > .imgeStore img{
    height: 317px;
}
footer > span{
    margin: 0 auto;
    max-width: 1375px;
}
.foot-top{
    display: flex;
    align-items: start;
    padding: 40px 30px;
    border-top: 1px solid #d0d0d0;
    margin: 0 60px;
}
.phone{
   display: flex;
   flex-direction: column;
   align-items: start;
   justify-content: left; 
   width: 25%;
   padding: 0 15px;
}
.text-phone{
    font-size: 14px;
    margin-bottom: 13px;
    text-transform: uppercase;
    color: #000;
}
.mert-phone{
    display: flex;
    margin-bottom: 10px;
    align-items: center;
    width: 100%;
}
.mert-phone .inpSpan{
    border-radius: 2px;
    background-color: #fefefe;
    border: solid 1px #a7a7a7;
    padding: 8px 0 8px 15px;
    width: 70%;
    overflow: hidden;
    line-height: 10px;
    cursor: pointer;
}
.mert-phone > .inpSpan >input{
    outline: none;
    border: hidden;
}
.mert-phone > span > button{
    background: #000;
    border: none;
    color: #fff;
    padding: 5px 10px;
    height: 36px;
    cursor: pointer;
}
.mert-phone > i{
    font-size: 25px;
}
.mert-phone > div{
    padding-left: 15px;
    font-size: 27px;
}
.mert-icon{
    display: flex;
    margin-bottom: 10px;
    align-items: center;
}
.mert-icon > i{
    font-size: 45px;
    margin-right: 15px;
}
.mota{
    font-size: 11px;
    margin-top: 5px;
}
.foot-bottom{
    display: flex;
    align-items: start;
    padding: 40px 90px;
    background:#f1f1f1;
}
.row-rule{
    display: flex;
    flex-direction: column;
    padding: 0 15px;
    width: 25%;
}
.row-rule > h4{
    margin-bottom: 10px;
    padding: 20px 20px 20px 0;
    font-size: 14px;
}
.footercontent {
    margin-bottom: 15px;
    color: #000;
}
.indam {
    font-weight: 600;
}
.font-14{
    font-size: 14px;
}
</style>