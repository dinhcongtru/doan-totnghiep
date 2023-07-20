<template>
    <div class="container">
        <div class="cf"></div>
        <div id="main">
            <div class="breadcrumb">
                <a href="/news">Trang chủ</a>
                » 
                <a>{{ this.new.title }}</a>
            </div>
            <div class="thirteen columns" id="main_content">
                <div class="box">
                    <div class="box_ct detail_page">
                        <h1 class="heading_page_news tp_title">{{ this.new.title }}</h1>
                        <em style="margin: 10px 0; display: block;">
                            <i class="fa fa-calendar"></i> Đăng ngày {{ this.new.timeZone }}                   
                        </em>
                        <div class="info_g">
                            <div class="kvgmc6g5 cxmmr5t8 oygrvhab hcukyx3x c1et5uql ii04i59q" style="margin:0px;white-space:pre-wrap;font-family:'Segoe UI Historic', 'Segoe UI', Helvetica, Arial, sans-serif;color:rgb(5,5,5);font-size:15px;">
                                <div style="font-family:inherit;">
                                    <img alt="" :src="this.new.img" style="width:600px;height:400px;">
                                </div>
                                <div style="font-family:inherit;">
                                    <div style="font-family:inherit;font-size:15px;white-space:pre-wrap;color:rgb(5,5,5);">
                                        <div class="kvgmc6g5 cxmmr5t8 oygrvhab hcukyx3x c1et5uql ii04i59q" style="margin:0px;white-space:pre-wrap;font-size:15px;">
                                            <div style="color:rgb(5,5,5);font-family:inherit;">
                                                <strong>
                                                    <span style="color:rgb(0,26,51);font-family:'Segoe UI', SegoeuiPc, 'San Francisco', 'Helvetica Neue', Helvetica, 'Lucida Grande', Roboto, Ubuntu, Tahoma, 'Microsoft Sans Serif', Arial, sans-serif;">{{ this.new.title }}</span>
                                                </strong>
                                            </div>
                                            <div style="color:rgb(5,5,5);font-family:inherit;height: 21px;"></div>
                                            <div v-for="(item,index) in tachChuoi" :key="index" style="color:rgb(5,5,5);font-family:inherit;white-space: pre-wrap;font-size: 15px;line-height: 1.4;">
                                                <span style="font-family:arial, helvetica, sans-serif;">
                                                    <span style="color:rgb(0,26,51); font-size: 15px;">{{ item.trim() }}.</span>
                                                </span>
                                            </div>
                                            
                                            <div>------------------</div>
                                            <div style="font-size: 15px;">Hệ thống cửa hàng tại Hà Nội:</div>
                                        </div>
                                        <div class="cxmmr5t8 oygrvhab hcukyx3x c1et5uql o9v6fnle ii04i59q" v-for="(item,index) in address" :key="index"  style="margin:0.5em 0px 0px;white-space:pre-wrap;font-family:'Segoe UI Historic', 'Segoe UI', Helvetica, Arial, sans-serif;color:rgb(5,5,5);font-size:15px;">
                                            <span style="font-family:arial, helvetica, sans-serif;">
                                                <span style="font-size:14px;">- {{ item }}</span>
                                            </span>
                                        </div>
                                        <div class="cxmmr5t8 oygrvhab hcukyx3x c1et5uql o9v6fnle ii04i59q"  style="margin:0.5em 0px 0px;white-space:pre-wrap;font-family:'Segoe UI Historic', 'Segoe UI', Helvetica, Arial, sans-serif;color:rgb(5,5,5);font-size:15px;">
                                            <span style="font-family:arial, helvetica, sans-serif;">
                                                <span style="font-size:14px;">Hotline: 0982.022.969</span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="function cf">
                            <iframe src="//www.facebook.com/plugins/like.php?href=https://krik.vn/grand-opening-krik-132-cau-giay-n99842.html&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;share=true&amp;appId=" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width: 145px; height: 20px;" allowtransparency="true" __idm_frm__="179"></iframe>
                        </div>
                        <div class="box box-relatedNews">
                            <div class="tab_cate_main">
                                <h3 class="link_Tab">Bài viết liên quan</h3>
                            </div>
                            <div class="box_ct news_page">
                                <ul>
                                    <li class="one-third column">
                                        <article class="news_item">
                                            <figure class="img_news">
                                                <a href="/new?name=tony4men-chinh-thuc-đoi-ten-thanh-krik">
                                                <img src="https://pos.nvncdn.net/be3159-662/art/20220222_fwFqi3XqntfiXKRAq1mVC8Lj.png" alt="TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK">
                                                </a>
                                            </figure>
                                            <h2 class="title_news">
                                                <a href="/new?name=tony4men-chinh-thuc-đoi-ten-thanh-krik">TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK</a>
                                            </h2>
                                            <div class="description_news">
                                                TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIKBạn thân mến,9 năm là cả một chặng đường dài đối với một Thương hiệu thời trang, để có một chỗ đứng vững trãi, cùng những thành công nhất định trên thị trường, Tony4men đã phải vượt qua rất nhiều khó khăn và thách thức.Nếu như bạn đã gắn bó cùng chúng mình trong suốt thời gian qua với sự hài lòng và tin tưởng, thì KRIK hứa hẹn sẽ đem tới cho bạn nhiều điều bất ngờ về sự mới mẻ, bùng nổ sáng tạo, và đặc biệt là những trải nghiệm tuyệt vời về sản phẩm cũng như chất lượng dịch vụ trong thời gian tới.Một phiên bản mới với sự hoàn hảo về mọi khía cạnh đến từ KRIK. Không đơn giản chỉ là thương hiệu thời trang, KRIK còn mang tầm nhìn và sứ mệnh mong muốn trở thành người bạn đồng hành của phái mạnh trong bất cứ hoàn cảnh nào.Cùng chúng mình đón chờ và trải nghiệm những điều tuyệt vời đang nằm ở phía trước nhé ^^
                                            </div>
                                        </article>
                                    </li>
                                    <li class="one-third column">
                                        <article class="news_item">
                                            <figure class="img_news">
                                                <a href="/new?name=sinh-nhat-7-tuoi">
                                                <img src="https://pos.nvncdn.net/be3159-662/art/20200519_VZo5w0FlWgEdWebONflm46ld.jpg" alt="Sinh Nhật 7 Tuổi">
                                                </a>
                                            </figure>
                                            <h2 class="title_news">
                                                <a href="/new?name=sinh-nhat-7-tuoi">Sinh Nhật 7 Tuổi</a>
                                            </h2>
                                            <div class="description_news">
                                                🎁𝗛𝗔𝗣𝗣𝗬 𝟳𝗧𝗛 𝗧𝗢𝗡𝗬𝟰𝗠𝗘𝗡 𝗕𝗜𝗥𝗧𝗛𝗗𝗔𝗬🎁‼TONY4MEN chính thức tròn 7 năm hình thành và phát triển.
Đó là một chặng đường không hẳn dài cũng không quá ngắn mà đó là quãng thời gian vừa đủ để chúng mình nỗ lực định hình phong cách thời trang cho đa số các bạn trẻ Việt Nam.⏰ Cũng trong thời gian đó, TONY4MEN đã trở thành địa chỉ quen thuộc của những tín đồ yêu thời trang khắp cả nước.Từ 1 cửa hàng nhỏ, chúng mình đã mở rộng và phát triển thành chuỗi hệ thống gồm 6 cửa hàng tại nội thành Hà Nội, luôn mang đến những phong cách mới mẻ, bắt kịp trend nhất đến với các bạn trẻ🛒 Nhân dịp sinh nhật lần thứ 7 này TONY4MEN xin dành tặng chương trình SALE TƯNG BỪNG - ĐỒNG GIÁ 49K như một lời tri ân đến khách hàng đã tin tưởng và ủng hộ chúng mình trong suốt thời gian vừa qua.
                                            </div>
                                        </article>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name:"DetailtNew",
    data(){
        return{
            address : [
                "132 Cầu Giấy","344 Cầu Giấy","338 Nguyễn Trãi","23 Chùa Bộc","209 Bạch Mai","189 Phố Nhổn","183 Trần Cung"
            ],
            // datta theo id bản tin
            new :{
                title : "GRAND OPENING - KRIK 132 CẦU GIẤY",
                timeZone : "14-04-2022",
                img :"https://pos.nvncdn.net/be3159-662/art/artCT/20220414_2s4h04UGHhVFkaHFCU9y6UQe.jpg",
                description : "GRAND OPENING | KRIK 132 CẦU GIẤY Sự kiện khai trương cửa hàng đầu tiên mang tên KRIK tại 132 Cầu Giấy trong những ngày vừa qua đã diễn ra thành công rực rỡ và ấn tượng.KRIK xin gửi lời cảm ơn chân thành nhất tới các vị khách hàng yêu quý, gia đình và bạn bè đã tới tham dự sự kiện và ủng hộ Thương hiệu.Chúng mình sẽ cố gắng phát triển thật lớn mạnh và nâng tầm dịch vụ để làm hài lòng tất cả khách hàng cũng như khẳng định vị trí Thương hiệu tại thị trường thời trang sắp tới"
            }
               
            
        }
    },
    computed:{
        // ttacjh  chuỗi từ description
        tachChuoi(){
            const sentences = this.new.description.split(".");
            return sentences;
        }
    }
}
</script>
<style scoped>
*,body{
    font-size: 14px;
}
.container {
    padding-right: 15px;
    padding-left: 15px;
    margin-right: auto;
    margin-left: auto;
}
@media (min-width: 768px){
.container {
    width: 750px;
}
}
@media (min-width: 992px){
.container {
    width: 970px;
}
}
@media (min-width: 1200px){
.container {
    width: 1170px;
}
}
@media (min-width: 1200px){
.container {
    max-width: 1175px;
    width: auto;
    padding: 0;
}
}
    .container {
    margin: 0 auto;
}
@media (min-width: 768px){
.container {
    width: 750px;
}
}
@media (min-width: 992px){
.container {
    width: 970px;
}
}
@media (min-width: 1024px){
.container {
    width: 1000px;
    padding: 0;
}
}
@media (min-width: 1200px){
.container {
    width: 1170px;
    padding: 0;
}
}
.btn-group-vertical > .btn-group:after, .btn-group-vertical > .btn-group:before, .btn-toolbar:after, .btn-toolbar:before, .clearfix:after, .clearfix:before, .container-fluid:after, .container-fluid:before, .container:after, .container:before, .dl-horizontal dd:after, .dl-horizontal dd:before, .form-horizontal .form-group:after, .form-horizontal .form-group:before, .modal-footer:after, .modal-footer:before, .nav:after, .nav:before, .navbar-collapse:after, .navbar-collapse:before, .navbar-header:after, .navbar-header:before, .navbar:after, .navbar:before, .pager:after, .pager:before, .panel-body:after, .panel-body:before, .row:after, .row:before {
    display: table;
    content: " ";
}

:after, :before {
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}
#main:after, .box:after, .box_ct:after, .cf:after, .container:after, .news_item:after, .pagination:after {
    clear: both;
    content: "";
    display: block;
    height: 0;
}
#main {
    padding-top: 10px;
}
.breadcrumb {
    padding: 8px 15px;
    margin-bottom: 20px;
    list-style: none;
    background-color: #f5f5f5;
    border-radius: 4px;
}
.breadcrumb {
    font-style: italic;
    margin-bottom: 10px;
}
a {
    background-color: transparent;
}
a {
    color: #252a2b;
    text-decoration: none;
    outline: none;
    -moz-transition: all 0.2s ease-in-out;
    -o-transition: all 0.2s ease-in-out;
    -webkit-transition: all 0.2s ease-in-out;
    transition: all 0.2s ease-in-out;
}
a {
    transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}
.breadcrumb a:first-child {
    padding-left: 0;
}
.breadcrumb a {
    padding: 0 5px;
}
.container .column, .container .columns {
    float: left;
    display: inline;
    margin-left: 0;
    margin-right: 0;
}
.container .thirteen.columns {
    width: 81.25%;
}
#main_content {
    width: 100%;
}
.box, .box_Tab, .tab_cate_main {
    position: relative;
}

.box {
    float: left;
    width: 100%;
    margin-bottom: 20px;
}
h1, h2, h3, h4, h5, h6 {
    color: #252a2b;
    margin: 0 0 13px 0;
    font-weight: 500;
    line-height: 1.2;
}
.heading_page, .heading_page_news {
    font-size: 22px;
    font-weight: 500;
    line-height: 1.3;
}
.heading_page_news {
    color: #c92014;
    border-bottom: 1px dotted #939393;
    margin-bottom: 10px;
    padding-bottom: 10px;
}
em {
    font-style: italic;
}
.fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
img {
    vertical-align: middle;
}

img {
    border: 0;
}
.info_g img {
    max-width: 100% !important;
    height: auto !important;
}
strong {
    font-weight: 700;
}

b, strong {
    font-weight: 700;
}
.function {
    border-bottom: 1px solid #d2d2d1;
    margin-bottom: 20px;
}
.box {
    float: left;
    width: 100%;
    margin-bottom: 20px;
}

.box, .box_Tab, .tab_cate_main {
    position: relative;
}
.tab_cate_main {
    /* border-top: 2px solid #e00000; */
    /* border-left: 3px solid #e00000; */
    /* background: #f2f2f2; */
    padding: 8px 0;
}

.box, .box_Tab, .tab_cate_main {
    position: relative;
}
.tab_cate_main .link_Tab {
    float: left;
}

.tab_cate_main .link_Tab {
    font-size: 18px;
    /* color: #e00000; */
    text-transform: uppercase;
}
.tab_cate_main:after {
    content: "";
    display: block;
    clear: both;
}
.news_page ul {
    margin-left: -15px;
}

ul {
    padding: 0;
    list-style-type: none;
}
ol, ul {
    margin-top: 0;
    margin-bottom: 10px;
}
.container .one-third.column {
    width: 33.3%;
}

@media only screen and (min-width: 992px){
.news_page li:nth-child(3n+1) {
    clear: both;
}
}
.container .column, .container .columns {
    float: left;
    display: inline;
    margin-left: 0;
    margin-right: 0;
}
article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}
article, aside, details, figcaption, figure, dialog, footer, header, hgroup, menu, nav, section {
    display: block;
}
figure {
    margin: 0;
}
.news_page .news_item .img_news {
    text-align: center;
    overflow: hidden;
    border: 1px solid #ddd;
    margin-bottom: 10px;
}
.img_news a {
    display: block;
    width: 100%;
    height: 240px;
    margin: auto;
}
img {
    max-width: 100%;
}
.news_page .news_item .img_news img, .news-img img {
    object-fit: cover;
}
.news_page .news_item .img_news img {
    width: 100%;
    height: 100%;
    object-fit: scale-down;
}
.news_item .title_news {
    font-size: 1em;
}
h1 a, h2 a, h3 a, h4 a, h5 a, h6 a {
    color: #252a2b;
    line-height: 1.1;
}
.news_item .description_news {
    display: block;
    height: 88px;
    overflow: hidden;
}
.news_page .news_item {
    margin: 15px 0 15px 15px;
    line-height: 1.3;
}
</style>