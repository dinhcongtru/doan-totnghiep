import { dynamicUrlProduct } from "@/methods";
const menuLayout = [
  {
    url: dynamicUrlProduct("Sale"),
    nameCate: "Sale",
    children: false,
    optionMenus: [
      {
        url: dynamicUrlProduct("Sale Đồng Giá 99k"),
        name: "Sale Đồng Giá 99k",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Sale Đồng Giá 149K"),
        name: "Sale Đồng Giá 149K",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Sale Off 50%"),
        name: "Sale Off 50%",
        isHasChildren: true,
      },
    ],
    itemProducts: [
      {
        url: dynamicUrlProduct("Áo Phông Regular Cotton 1063"),
        name: "Áo Phông Regular Cotton 1063",
        category: "Áo Polo",
        img: "sale1.jpeg",
      },
      {
        url: dynamicUrlProduct("Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022"),
        name: "Áo Sơ Mi Cổ Đức Dài Tay Slim Polyster 3022",
        category: "Áo Sơ Mi",
        img: "sale2.jpeg",
      },
      {
        url: dynamicUrlProduct("Áo Sơ Mi Cổ Đức Dài Tay Regular Cotton 3010"),
        name: "Áo Sơ Mi Cổ Đức Dài Tay Regular Cotton 3010",
        category: "Áo Sơ Mi",
        img: "sale3.jpeg",
      },
    ],
    isHasOption: true,
  },
  {
    url: dynamicUrlProduct("Áo Nam"),
    nameCate: "Áo Nam",
    children: true,
    optionMenus: [
      {
        url: dynamicUrlProduct("Áo Blazer"),
        name: "Áo Blazer",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Áo Phông"),
        name: "Áo Phông",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Áo Sơ Mi"),
        name: "Áo Sơ Mi",
        isHasChildren: true,
      },
      {
        url: dynamicUrlProduct("Áo Tanktop"),
        name: "Áo Tanktop",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Áo Polo"),
        name: "Áo Polo",
        isHasChildren: false,
      },
    ],
    itemProducts: [
      {
        url: dynamicUrlProduct("Áo Polo Cổ Đức Regular Cotton 2068"),
        name: "Áo Polo Cổ Đức Regular Cotton 2068",
        category: "Áo Polo",
        img: "áo1.jpeg",
      },
      {
        url: dynamicUrlProduct("Áo Phông Classic Cotton 1094"),
        name: "Áo Phông Classic Cotton 1094",
        category: "Áo Phông",
        img: "áo2.jpeg",
      },
      {
        url: dynamicUrlProduct("Áo Polo Cổ Đức Classic Cotton 2065"),
        name: "Áo Polo Cổ Đức Classic Cotton 2065",
        category: "Áo Polo",
        img: "áo3.jpeg",
      },
    ],
    optionChildren: [
      {
        url: dynamicUrlProduct("Sơ mi cộc tay"),
        name: "Sơ mi cộc tay",
      },
      {
        url: dynamicUrlProduct("Sơ mi dài tay"),
        name: "Sơ mi dài tay",
      },
    ],
    isHasOption: true,
  },
  {
    url: dynamicUrlProduct("quần nam"),
    nameCate: "quần nam",
    children: false,
    optionMenus: [
      {
        url: dynamicUrlProduct("Quần Jeans"),
        name: "Quần Jeans",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Quần Short"),
        name: "Quần Short",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Quần Âu"),
        name: "Quần Âu",
        isHasChildren: true,
      },
      {
        url: dynamicUrlProduct("Quần Jogge"),
        name: "Quần Jogge",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Quần Kaki"),
        name: "Quần Kaki",
        isHasChildren: false,
      },
    ],
    itemProducts: [
      {
        url: dynamicUrlProduct("Quần Linen Loosefit Cotton 6511"),
        name: "Quần Linen Loosefit Cotton 6511",
        category: "Quần Jeans",
        img: "quan1.jpeg",
      },
      {
        url: dynamicUrlProduct("Quần Short Regular Kaki 8036"),
        name: "Quần Short Regular Kaki 8036",
        category: "Quần Short",
        img: "quan2.jpeg",
      },
      {
        url: dynamicUrlProduct("Quần Kaki Slim Cotton 6507"),
        name: "Quần Kaki Slim Cotton 6507",
        category: "Quần Kaki",
        img: "quan3.webp",
      },
    ],
    isHasOption: true,
  },
  {
    url: dynamicUrlProduct("phụ kiện"),
    nameCate: "phụ kiện",
    children: false,
    optionMenus: [
      {
        url: dynamicUrlProduct("Dây Lưng"),
        name: "Dây Lưng",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Balo + Cặp Xách"),
        name: "Balo + Cặp Xách",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Giày Dép"),
        name: "Giày Dép",
        isHasChildren: true,
      },
      {
        url: dynamicUrlProduct("Mũ Nam"),
        name: "Mũ Nam",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Tất Nam"),
        name: "Tất Nam",
        isHasChildren: false,
      },
      {
        url: dynamicUrlProduct("Quần Lót"),
        name: "Quần Lót",
        isHasChildren: false,
      },
    ],
    itemProducts: [
      {
        url: dynamicUrlProduct("Giày Oxford 0026"),
        name: "Giày Oxford 0026",
        category: "Giày Dép",
        img: "pk1.jpeg",
      },
      {
        url: dynamicUrlProduct("Giày Loafer 0025"),
        name: "Giày Loafer 0025",
        category: "Giày Dép",
        img: "pk2.jpeg",
      },
      {
        url: dynamicUrlProduct("Balo Da 0020"),
        name: "Balo Da 0020",
        category: "Ballo + Cặp xách",
        img: "pk3.jpeg",
      },
    ],
    isHasOption: true,
  },
  {
    url: dynamicUrlProduct("album"),
    nameCate: "album",
    children: false,
    isHasOption: false,
  },
  {
    url: dynamicUrlProduct("Tin tức"),
    nameCate: "Tin tức",
    children: false,
    isHasOption: false,
  },
];
const DataCity = [
  "- Tỉnh thành -",
  "Hà Nội",
  "Hồ Chí Minh",
  "An Giang",
  "Bà Rịa-Vũng Tàu",
  "Bắc Ninh",
  "Nam Định",
  "Ninh Bình",
  "Hải Phòng",
  "Đà Nẵng",
  "Cần Thơ",
  "Bình Dương",
  "Bình Định",
  "Khánh Hòa",
];
const itemSize = [
  {
    value: "S",
    selected: false,
  },
  {
    value: "M",
    selected: false,
  },
  {
    value: "L",
    selected: false,
  },
  {
    value: "XL",
    selected: false,
  },
];
const itemCover = [
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp1.jpeg",
    name: "Áo Polo Cổ Đức Regular Cotton 2068",
    price: "349,000",
  },
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp2.webp",
    name: "Áo Polo Cổ Đức Regular Cotton 2068",
    price: "349,000",
  },
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp3.webp",
    name: "Áo Polo Cổ Đức Regular Cotton 2068",
    price: "349,000",
  },
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp4.jpeg",
    name: "Áo Polo Cổ Đức Regular Cotton 2068",
    price: "349,000",
  },
];
const itemSort = ["Mới nhất", "Giá giảm dần", "Giá tăng dần", "Sale"];
const listNewProducts = [
  {
    hrefPro: dynamicUrlProduct("name defaultdsd"),
    category: "Áo Nam",
    imgProMain: "sp3.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "Quần Jeans Loose Fit Cotton 6005",
    price: 479000,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },

  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
];
const colorData = [
  { checkedColor: false, title: "Đỏ", background: "#FF0000" },
  { checkedColor: false, title: "Than Tím", background: "#000044" },
  { checkedColor: false, title: "Xanh", background: "#0000FF" },
  { checkedColor: false, title: "Vàng", background: "#FFFF00" },
  { checkedColor: false, title: "Ghi Đậm", background: "#808080" },
  { checkedColor: false, title: "Nâu", background: "#663300" },
  { checkedColor: false, title: "Hồng", background: "#FF0066" },
  { checkedColor: false, title: "Be", background: "#" },
  { checkedColor: false, title: "Đen", background: "#000000" },
  { checkedColor: false, title: "Trắng", background: "#FFFFFF" },
  { checkedColor: false, title: "Ghi", background: "#" },
];
const sizeData = [
  { checkedSize: false, size: "28" },
  { checkedSize: false, size: "29" },
  { checkedSize: false, size: "30" },
  { checkedSize: false, size: "31" },
  { checkedSize: false, size: "32" },
  { checkedSize: false, size: "33" },
  { checkedSize: false, size: "34" },
  { checkedSize: false, size: "S" },
  { checkedSize: false, size: "M" },
  { checkedSize: false, size: "L" },
  { checkedSize: false, size: "XL" },
  { checkedSize: false, size: "2XL" },
];
const princeData = [
  { checkedPrice: false, price: "Dưới 200,000" },
  { checkedPrice: false, price: "Từ 200,000 - 500,000" },
  { checkedPrice: false, price: "Từ 500,000 - 1,000,000" },
  { checkedPrice: false, price: "Hơn 1,000,000" },
];
const chatlieu = [
  "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
  "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
  "2% Spandex tạo độ co giãn, thoải mái khi vận động",
];
const kieudang = [
  "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
];
const chitiet = [
  "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
  "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
  "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
];
const optionProSale = ["đồng giá 99k", "Đồng giá 149k", "Sale off 50%"];
const optionProMenshirt = ["áo Blazer", "Áo sơ mi", "Áo Tanktop", "Áo polo"];
const optionProMentrousers = [
  "quần jeans",
  "Quần short",
  "Quần âu",
  "Quần Jogger",
  "Quần kaki",
];
const optionProPhukien = [
  "dây lưng",
  "Balo + cặp xách",
  "Giày dép",
  "Mũ nam",
  "Quần Lót",
];
const listAlbum = [
  {
    urlAlbum: "#",
    imgAlbum: "alb1.jpeg",
    text: "FREEDOM | SUMMER '23 COLLECTION",
  },
  {
    urlAlbum: "#",
    imgAlbum: "alb2.webp",
    text: "ENJOY YOURSELF | NEW LOOKBOOK 2023",
  },
  {
    urlAlbum: "#",
    imgAlbum: "alb3.webp",
    text: "FROSTY | WINTER 2022 COLLECTION",
  },
  {
    urlAlbum: "#",
    imgAlbum: "alb4.webp",
    text: "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
  },
];
const listAlbumTinTuc = [
  {
    urlAlbum: "#",
    imgAlbum: "tin1.jpg",
    text: "GRAND OPENING - KRIK 132 CẦU GIẤY",
    describe:
      "GRAND OPENING | KRIK 132 CẦU GIẤYSự kiện khai trương cửa hàng đầu tiên mang tên KRIK tại 132 Cầu Giấy trong những ngày vừa qua đã diễn ra thành công rực rỡ và ấn tượng.KRIK xin gửi lời cảm ơn chân thành nhất tới các vị khách hàng yêu quý, gia đình và bạn bè đã tới tham dự sự kiện và ủng hộ Thương hiệu.Chúng mình sẽ cố gắng phát triển thật lớn mạnh và nâng tầm dịch vụ để làm hài lòng tất cả khách hàng cũng như khẳng định vị trí Thương hiệu tại thị trường thời trang sắp tới.------------------Hệ thống cửa hàng tại Hà Nội:- 132 Cầu Giấy- 344 Cầu Giấy- 338 Nguyễn Trãi- 23 Chùa Bộc- 209 Bạch Mai- 189 Phố Nhổn- 183 Trần CungHotline: 0982.022.969",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "#",
    imgAlbum: "tin2.webp",
    text: "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK",
    describe:
      "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIKBạn thân mến,9 năm là cả một chặng đường dài đối với một Thương hiệu thời trang, để có một chỗ đứng vững trãi, cùng những thành công nhất định trên thị trường, Tony4men đã phải vượt qua rất nhiều khó khăn và thách thức.Nếu như bạn đã gắn bó cùng chúng mình trong suốt thời gian qua với sự hài lòng và tin tưởng, thì KRIK hứa hẹn sẽ đem tới cho bạn nhiều điều bất ngờ về sự mới mẻ, bùng nổ sáng tạo, và đặc biệt là những trải nghiệm tuyệt vời về sản phẩm cũng như chất lượng dịch vụ trong thời gian tới.Một phiên bản mới với sự hoàn hảo về mọi khía cạnh đến từ KRIK. Không đơn giản chỉ là thương hiệu thời trang, KRIK còn mang tầm nhìn và sứ mệnh mong muốn trở thành người bạn đồng hành của phái mạnh trong bất cứ hoàn cảnh nào.Cùng chúng mình đón chờ và trải nghiệm những điều tuyệt vời đang nằm ở phía trước nhé ^^",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "#",
    imgAlbum: "tin3.webp",
    text: "Cách thức đặt hàng",
    describe:
      "Cách thức đặt hàngĐặt hàng qua Hotline: Gọi trực tiếp đến sđt: 0982.022.969 để được nhân viên tư vấn hỗ trợ nhanh nhất về sản phẩm và dịch vụ.Đặt hàng trên FB: Gửi ảnh hoặc mã sp mà mình quan tâm đến Page KRIK (m.me/krik.vn). Nhân viên tư vấn sẽ trả lời nhanh nhất khi có thể. Liên hệ trực tiếp số hotline: 0982.022.969 để được hỗ trợ nhanh nhất.Đặt hàng trên Web:B1: Click vào sản phẩm muốn đặt hàngB2: Chọn màu sắc, size và số lượng muốn đặt rồi Click [Mua Ngay]B3: Click vào [ Tiến hành đặt hàng ] để chuyển sang giao diện điền thông tin giao hàng hoặc có thể click vào [ Xem chi tiết giỏ hàng ] để xem lại giỏ hàng của mình.B4: Điền thông tin vào form đặt hàng: Họ tên, số điện thoại, email, địa chỉB5: Chọn phương thức thanh toán: COD (thanh toán tại nhà)B6: Hoàn tất đơn hàngKRIK sẽ xác nhận đơn hàng bằng cách gọi điện. Vui lòng nghe máy để chúng tôi có thể lên đơn thành công giúp bạn.",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "#",
    imgAlbum: "tin4.webp",
    text: "Chính sách thành viên",
    describe:
      "Chính sách thành viênMEMBER CARD: Tổng giá trị hóa đơn đã mua từ 0-3tr được tích 3% trên tổng giá trị hóa đơn.VIP CARD: Tổng giá trị hóa đơn đã mua từ 3-6tr được tích 5% trên tổng giá trị hóa đơnSUPERVIP CARD: Tổng giá trị hóa đơn đã mua >6tr được tích 8% trên tổng giá trị hóa đơn.⇒ Khách hàng mua hàng (tại cửa hàng) trong tuần sinh nhật ( trước và sau ngày sinh nhật 3 ngày ) được giảm 10% trên tổng hóa đơn.",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
];
const listNewProductHomePages = [
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
  {
    hrefPro: dynamicUrlProduct("name default"),
    category: "Áo Nam",
    imgProMain: "sp2.webp",
    listcolors: [
      {
        selected: false,
        name: "Be",
        image: "sp3.webp",
      },
      {
        selected: false,
        name: "Trắng",
        image: "sp4.jpeg",
      },
    ],
    name: "name default",
    price: 0,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
];
const product = {
  id : 1,
  code : "NPMCODE001",
  productName : "Quần Jeans Loose Fit Cotton 6005",
  categoryName :"Áo NAM",
  listImages : ["sp1.jpeg","sp2.webp","sp3.webp","sp4.jpeg","sale1.jpeg","sale2.jpeg","sale3.jpeg"],
  mainImage : "sp3.webp",
  listColors :[
    {
      selected: false,
      name: "Be",
      image: "sp1.jpeg",
    },
    {
      selected: false,
      name: "Trắng",
      image: "sp2.webp",
    },
    {
      selected: false,
      name: "xanh",
      image: "sp3.webp",
    },
    {
      selected: false,
      name: "Nâu",
      image: "sp4.jpeg",
    },
  ],
  statusProduct : "Còn Hàng",
  price : 1139000,
  itemSizes : [
    {
      value: "S",
      selected: false,
    },
    {
      value: "M",
      selected: false,
    },
    {
      value: "L",
      selected: false,
    },
    {
      value: "XL",
      selected: false,
    },
  ],
  quantity : 20,
  chatlieu : [
    "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
    "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
    "2% Spandex tạo độ co giãn, thoải mái khi vận động",
  ],
  kieudang : [
    "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
  ],
  chitiet : [
    "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
    "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
    "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
  ],

}
export {
  menuLayout,
  DataCity,
  itemSize,
  itemCover,
  itemSort,
  listNewProducts,
  colorData,
  sizeData,
  princeData,
  chatlieu,
  kieudang,
  chitiet,
  optionProSale,
  optionProMenshirt,
  optionProMentrousers,
  optionProPhukien,
  listAlbum,
  listAlbumTinTuc,
  listNewProductHomePages,
  product
};
