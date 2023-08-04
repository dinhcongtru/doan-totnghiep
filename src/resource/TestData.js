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
  // {
  //   url: dynamicUrlProduct("album"),
  //   nameCate: "album",
  //   children: false,
  //   isHasOption: false,
  // },
  // {
  //   url: dynamicUrlProduct("Tin tức"),
  //   nameCate: "Tin tức",
  //   children: false,
  //   isHasOption: false,
  // },
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
const dataChooseCity = [
  "Chọn Tỉnh/ thành phố",
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
const dataChooseQuan = [
  "Chọn Quận/ huyện",
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
const dataChoosePhuong = [
  "Chọn Phường/ xã",
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
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp4.jpeg",
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
  {
    urlHref: "#",
    title: "Áo Polo Cổ Đức Regular Cotton 2068",
    imgCover: "sp4.jpeg",
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
    id: 1,
    code: "NPMCODE001",
    productName: "Quần Jeans Loose Fit Cotton 6005",
    categoryName: "Áo NAM",
    listColors: [
      {
        selected: false,
        name: "Be",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sp1.jpeg",
          },
          {
            selected: false,
            image: "sp2.webp",
          },
          {
            selected: false,
            image: "sp3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Trắng",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sale1.jpeg",
          },
          {
            selected: false,
            image: "sale2.jpeg",
          },
          {
            selected: false,
            image: "sale3.jpeg",
          },
        ],
      },
      {
        selected: false,
        name: "xanh",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "quan1.jpeg",
          },
          {
            selected: false,
            image: "quan2.jpeg",
          },
          {
            selected: false,
            image: "quan3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Nâu",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "áo1.jpeg",
          },
          {
            selected: false,
            image: "áo2.jpeg",
          },
          {
            selected: false,
            image: "áo3.jpeg",
          },
        ],
      },
    ],
    statusProduct: "Còn Hàng",
    price: 435000,
    itemSizes: [
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
    chatlieu: [
      "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
      "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
      "2% Spandex tạo độ co giãn, thoải mái khi vận động",
    ],
    kieudang: [
      "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
    ],
    chitiet: [
      "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
      "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
      "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
    ],
  },
  {
    id: 2,
    code: "NPDE001",
    productName: "Quần Jeans Loose Fit Cotton 6005",
    categoryName: "Áo NAM",
    listColors: [
      {
        selected: false,
        name: "Be",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sp1.jpeg",
          },
          {
            selected: false,
            image: "sp2.webp",
          },
          {
            selected: false,
            image: "sp3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Trắng",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sale1.jpeg",
          },
          {
            selected: false,
            image: "sale2.jpeg",
          },
          {
            selected: false,
            image: "sale3.jpeg",
          },
        ],
      },
      {
        selected: false,
        name: "xanh",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "quan1.jpeg",
          },
          {
            selected: false,
            image: "quan2.jpeg",
          },
          {
            selected: false,
            image: "quan3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Nâu",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "áo1.jpeg",
          },
          {
            selected: false,
            image: "áo2.jpeg",
          },
          {
            selected: false,
            image: "áo3.jpeg",
          },
        ],
      },
    ],
    statusProduct: "Còn Hàng",
    price: 435000,
    itemSizes: [
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
    chatlieu: [
      "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
      "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
      "2% Spandex tạo độ co giãn, thoải mái khi vận động",
    ],
    kieudang: [
      "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
    ],
    chitiet: [
      "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
      "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
      "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
    ],
  },
  {
    id: 3,
    code: "NFSSODE001",
    productName: "Quần Jeans Loose Fit Cotton 6005",
    categoryName: "Áo NAM",
    listColors: [
      {
        selected: false,
        name: "Be",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sp1.jpeg",
          },
          {
            selected: false,
            image: "sp2.webp",
          },
          {
            selected: false,
            image: "sp3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Trắng",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sale1.jpeg",
          },
          {
            selected: false,
            image: "sale2.jpeg",
          },
          {
            selected: false,
            image: "sale3.jpeg",
          },
        ],
      },
      {
        selected: false,
        name: "xanh",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "quan1.jpeg",
          },
          {
            selected: false,
            image: "quan2.jpeg",
          },
          {
            selected: false,
            image: "quan3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Nâu",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "áo1.jpeg",
          },
          {
            selected: false,
            image: "áo2.jpeg",
          },
          {
            selected: false,
            image: "áo3.jpeg",
          },
        ],
      },
    ],
    statusProduct: "Còn Hàng",
    price: 435000,
    itemSizes: [
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
    chatlieu: [
      "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
      "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
      "2% Spandex tạo độ co giãn, thoải mái khi vận động",
    ],
    kieudang: [
      "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
    ],
    chitiet: [
      "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
      "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
      "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
    ],
  },
  {
    id: 4,
    code: "NPMCODFDS01",
    productName: "Quần Jeans Loose Fit Cotton 6005",
    categoryName: "Áo NAM",
    listColors: [
      {
        selected: false,
        name: "Be",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sp1.jpeg",
          },
          {
            selected: false,
            image: "sp2.webp",
          },
          {
            selected: false,
            image: "sp3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Trắng",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sale1.jpeg",
          },
          {
            selected: false,
            image: "sale2.jpeg",
          },
          {
            selected: false,
            image: "sale3.jpeg",
          },
        ],
      },
      {
        selected: false,
        name: "xanh",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "quan1.jpeg",
          },
          {
            selected: false,
            image: "quan2.jpeg",
          },
          {
            selected: false,
            image: "quan3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Nâu",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "áo1.jpeg",
          },
          {
            selected: false,
            image: "áo2.jpeg",
          },
          {
            selected: false,
            image: "áo3.jpeg",
          },
        ],
      },
    ],
    statusProduct: "Còn Hàng",
    price: 435000,
    itemSizes: [
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
    chatlieu: [
      "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
      "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
      "2% Spandex tạo độ co giãn, thoải mái khi vận động",
    ],
    kieudang: [
      "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
    ],
    chitiet: [
      "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
      "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
      "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
    ],
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
    urlAlbum:
      "https://www.facebook.com/Krik.vn/posts/pfbid0cz9kKgyxePkbSzgxkMZdNjdxmUVWMhxeUjAHmPLLFySTgKnxURjoAKUR9NMMVcw8l",
    imgAlbum: "alb1.jpeg",
    text: "FREEDOM | SUMMER '23 COLLECTION",
  },
  {
    urlAlbum:
      "https://www.facebook.com/Krik.vn/posts/pfbid031KVFmNoEXQ3tLeSz41z6cCQRt4xMfAPhGL8hZDcXssCTckRFfoHLE3HBCdNBvTRl",
    imgAlbum: "alb2.webp",
    text: "ENJOY YOURSELF | NEW LOOKBOOK 2023",
  },
  {
    urlAlbum:
      "https://www.facebook.com/Krik.vn/posts/pfbid02jqbpYwAAC7qor6Md4kcdVxkA6ukrtynWNjRQDwG2GsULCYY1ek5pJ9ysKkfC6GVFl",
    imgAlbum: "alb3.webp",
    text: "FROSTY | WINTER 2022 COLLECTION",
  },
  {
    urlAlbum:
      "https://www.facebook.com/Krik.vn/posts/pfbid0221i7v5Mf3XYAW6mb9nA7WZHfHj27kcEKsZb4CqHstkczQ9hMb9QBYSuPwMT6iu44l",
    imgAlbum: "alb4.webp",
    text: "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
  },
];

const listAlbumTinTuc = [
  {
    urlAlbum: "/new?name=grand-opening---krik-132-cau-giay",
    imgAlbum: "tin1.jpg",
    text: "GRAND OPENING - KRIK 132 CẦU GIẤY",
    describe:
      "GRAND OPENING | KRIK 132 CẦU GIẤYSự kiện khai trương cửa hàng đầu tiên mang tên KRIK tại 132 Cầu Giấy trong những ngày vừa qua đã diễn ra thành công rực rỡ và ấn tượng.KRIK xin gửi lời cảm ơn chân thành nhất tới các vị khách hàng yêu quý, gia đình và bạn bè đã tới tham dự sự kiện và ủng hộ Thương hiệu.Chúng mình sẽ cố gắng phát triển thật lớn mạnh và nâng tầm dịch vụ để làm hài lòng tất cả khách hàng cũng như khẳng định vị trí Thương hiệu tại thị trường thời trang sắp tới.------------------Hệ thống cửa hàng tại Hà Nội:- 132 Cầu Giấy- 344 Cầu Giấy- 338 Nguyễn Trãi- 23 Chùa Bộc- 209 Bạch Mai- 189 Phố Nhổn- 183 Trần CungHotline: 0982.022.969",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "/new?name=tony4men-chinh-thuc-đoi-ten-thanh-krik",
    imgAlbum: "tin2.webp",
    text: "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK",
    describe:
      "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIKBạn thân mến,9 năm là cả một chặng đường dài đối với một Thương hiệu thời trang, để có một chỗ đứng vững trãi, cùng những thành công nhất định trên thị trường, Tony4men đã phải vượt qua rất nhiều khó khăn và thách thức.Nếu như bạn đã gắn bó cùng chúng mình trong suốt thời gian qua với sự hài lòng và tin tưởng, thì KRIK hứa hẹn sẽ đem tới cho bạn nhiều điều bất ngờ về sự mới mẻ, bùng nổ sáng tạo, và đặc biệt là những trải nghiệm tuyệt vời về sản phẩm cũng như chất lượng dịch vụ trong thời gian tới.Một phiên bản mới với sự hoàn hảo về mọi khía cạnh đến từ KRIK. Không đơn giản chỉ là thương hiệu thời trang, KRIK còn mang tầm nhìn và sứ mệnh mong muốn trở thành người bạn đồng hành của phái mạnh trong bất cứ hoàn cảnh nào.Cùng chúng mình đón chờ và trải nghiệm những điều tuyệt vời đang nằm ở phía trước nhé ^^",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "/new?name=cach-thuc-đat-hang",
    imgAlbum: "tin3.webp",
    text: "Cách thức đặt hàng",
    describe:
      "Cách thức đặt hàngĐặt hàng qua Hotline: Gọi trực tiếp đến sđt: 0982.022.969 để được nhân viên tư vấn hỗ trợ nhanh nhất về sản phẩm và dịch vụ.Đặt hàng trên FB: Gửi ảnh hoặc mã sp mà mình quan tâm đến Page KRIK (m.me/krik.vn). Nhân viên tư vấn sẽ trả lời nhanh nhất khi có thể. Liên hệ trực tiếp số hotline: 0982.022.969 để được hỗ trợ nhanh nhất.Đặt hàng trên Web:B1: Click vào sản phẩm muốn đặt hàngB2: Chọn màu sắc, size và số lượng muốn đặt rồi Click [Mua Ngay]B3: Click vào [ Tiến hành đặt hàng ] để chuyển sang giao diện điền thông tin giao hàng hoặc có thể click vào [ Xem chi tiết giỏ hàng ] để xem lại giỏ hàng của mình.B4: Điền thông tin vào form đặt hàng: Họ tên, số điện thoại, email, địa chỉB5: Chọn phương thức thanh toán: COD (thanh toán tại nhà)B6: Hoàn tất đơn hàngKRIK sẽ xác nhận đơn hàng bằng cách gọi điện. Vui lòng nghe máy để chúng tôi có thể lên đơn thành công giúp bạn.",
    urlXemthem: "#",
    textA: "Xem Thêm",
  },
  {
    urlAlbum: "/new?name=chinh-sach-thanh-vien",
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
    price: 349000,
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
    price: 349000,
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
    price: 349000,
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
    price: 349000,
    textBuy: "Mua nhanh",
    textDes: "Xem Chi Tiết",
  },
];
const product = {
  id: 1,
  code: "NPMCODE001",
  productName: "Quần Jeans Loose Fit Cotton 6005",
  categoryName: "Áo NAM",
  listColors: [
    {
      selected: false,
      name: "Be",
      itemSize: [
        {
          value: "S",
          selected: false,
          quantity: 10,
        },
        {
          value: "M",
          selected: false,
          quantity: 10,
        },
        {
          value: "L",
          selected: false,
          quantity: 10,
        },
        {
          value: "XL",
          selected: false,
          quantity: 10,
        },
      ],
      listImages: [
        {
          selected: true,
          image: "sp1.jpeg",
        },
        {
          selected: false,
          image: "sp2.webp",
        },
        {
          selected: false,
          image: "sp3.webp",
        },
        
      ],
    },
    {
      selected: false,
      name: "Trắng",
      itemSize: [
        {
          value: "S",
          selected: false,
          quantity: 10,
        },
        {
          value: "M",
          selected: false,
          quantity: 10,
        },
        {
          value: "L",
          selected: false,
          quantity: 10,
        },
        {
          value: "XL",
          selected: false,
          quantity: 10,
        },
      ],
      listImages: [
        {
          selected: true,
          image: "sale1.jpeg",
        },
        {
          selected: false,
          image: "sale2.jpeg",
        },
        {
          selected: false,
          image: "sale3.jpeg",
        },
      ],
    },
    {
      selected: false,
      name: "Xanh",
      itemSize: [
        {
          value: "S",
          selected: false,
          quantity: 10,
        },
        {
          value: "M",
          selected: false,
          quantity: 10,
        },
        {
          value: "L",
          selected: false,
          quantity: 10,
        },
        {
          value: "XL",
          selected: false,
          quantity: 10,
        },
      ],
      listImages: [
        {
          selected: true,
          image: "quan1.jpeg",
        },
        {
          selected: false,
          image: "quan2.jpeg",
        },
        {
          selected: false,
          image: "quan3.webp",
        },
      ],
    },
    {
      selected: false,
      name: "Nâu",
      itemSize: [
        {
          value: "S",
          selected: false,
          quantity: 10,
        },
        {
          value: "M",
          selected: false,
          quantity: 10,
        },
        {
          value: "L",
          selected: false,
          quantity: 10,
        },
        {
          value: "XL",
          selected: false,
          quantity: 10,
        },
      ],
      listImages: [
        {
          selected: true,
          image: "áo1.jpeg",
        },
        {
          selected: false,
          image: "áo2.jpeg",
        },
        {
          selected: false,
          image: "áo3.jpeg",
        },
      ],
    },
  ],
  statusProduct: "Còn Hàng",
  price: 435000,
  itemSizes: [
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
  chatlieu: [
    "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
    "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
    "2% Spandex tạo độ co giãn, thoải mái khi vận động",
  ],
  kieudang: [
    "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
  ],
  chitiet: [
    "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
    "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
    "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
  ],
};
const productLIst = [
  {
    id: 1,
    code: "NPMCODE001",
    productName: "Quần Jeans Loose Fit Cotton 6005",
    categoryName: "Áo NAM",
    listColors: [
      {
        selected: false,
        name: "Be",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sp1.jpeg",
          },
          {
            selected: false,
            image: "sp2.webp",
          },
          {
            selected: false,
            image: "sp3.webp",
          },
          
        ],
      },
      {
        selected: false,
        name: "Trắng",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "sale1.jpeg",
          },
          {
            selected: false,
            image: "sale2.jpeg",
          },
          {
            selected: false,
            image: "sale3.jpeg",
          },
        ],
      },
      {
        selected: false,
        name: "Xanh",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "quan1.jpeg",
          },
          {
            selected: false,
            image: "quan2.jpeg",
          },
          {
            selected: false,
            image: "quan3.webp",
          },
        ],
      },
      {
        selected: false,
        name: "Nâu",
        itemSize: [
          {
            value: "S",
            selected: false,
            quantity: 10,
          },
          {
            value: "M",
            selected: false,
            quantity: 10,
          },
          {
            value: "L",
            selected: false,
            quantity: 10,
          },
          {
            value: "XL",
            selected: false,
            quantity: 10,
          },
        ],
        listImages: [
          {
            selected: true,
            image: "áo1.jpeg",
          },
          {
            selected: false,
            image: "áo2.jpeg",
          },
          {
            selected: false,
            image: "áo3.jpeg",
          },
        ],
      },
    ],
    statusProduct: "Còn Hàng",
    price: 435000,
    itemSizes: [
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
    chatlieu: [
      "77% Polyester chống nhăn hiệu quả, giữ nhiệt tốt, hạn chế hiện tượng chùng nhão",
      "21% Rayon tạo độ sáng bóng, mềm mịn và sang trọng cho áo",
      "2% Spandex tạo độ co giãn, thoải mái khi vận động",
    ],
    kieudang: [
      "Phom Classic rộng thoáng, tôn lên vóc dáng người mặc và tạo vẻ đẹp trẻ trung, thanh lịch.",
    ],
    chitiet: [
      "Màu sắc lạ mắt dễ phối đồ: Be hơi ánh xanh ngọc, đẹp hơn khi kết hợp cùng quần Jeans, quần Kaki hoặc quần âu đều được.",
      "Thiết kế cổ bẻ vạt chéo tạo sự thanh lịch, sang trọng",
      "Thiết kế túi nắp 2 bên tạo điểm nhấn trẻ trung.",
    ],
  }
]
const listAlbums = [
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid0cz9kKgyxePkbSzgxkMZdNjdxmUVWMhxeUjAHmPLLFySTgKnxURjoAKUR9NMMVcw8l",
    title: "FREEDOM | SUMMER '23 COLLECTION",
    img: "https://pos.nvncdn.net/be3159-662/album/20230506_bptAlkJ8.jpeg",
    alt: "FREEDOM | SUMMER '23 COLLECTION",
    content: "FREEDOM | SUMMER '23 COLLECTION",
    clear: true,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid031KVFmNoEXQ3tLeSz41z6cCQRt4xMfAPhGL8hZDcXssCTckRFfoHLE3HBCdNBvTRl",
    title: "ENJOY YOURSELF | NEW LOOKBOOK 2023",
    img: "https://pos.nvncdn.net/be3159-662/album/20230320_hMGjvhkQ.png",
    alt: "ENJOY YOURSELF | NEW LOOKBOOK 2023",
    content: "ENJOY YOURSELF | NEW LOOKBOOK 2023",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid02jqbpYwAAC7qor6Md4kcdVxkA6ukrtynWNjRQDwG2GsULCYY1ek5pJ9ysKkfC6GVFl",
    title: "FROSTY | WINTER 2022 COLLECTION",
    img: "https://pos.nvncdn.net/be3159-662/album/20221225_QuHXc4W2yck4G0il14HFWw95.png",
    alt: "FROSTY | WINTER 2022 COLLECTION",
    content: "FROSTY | WINTER 2022 COLLECTION",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid0221i7v5Mf3XYAW6mb9nA7WZHfHj27kcEKsZb4CqHstkczQ9hMb9QBYSuPwMT6iu44l",
    title: "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
    img: "https://pos.nvncdn.net/be3159-662/album/20221212_9ibRtOIynHiSr1VS4JxrmqQI.png",
    alt: "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
    content: "SPECIAL XMAS | HOLIDAY COLLECTION 2022",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid0DZiEr25T9W3hgbBc6E72z3y6SFyG9SUUou6aE1Hdn3z4SSd5hwaukQzmj917iKz1l",
    title: "MULTI SIDED | WINTER 2022 COLLECTION",
    img: "https://pos.nvncdn.net/be3159-662/album/20221206_mu3rV1f47nVBTYiSdolTAEXf.png",
    alt: "MULTI SIDED | WINTER 2022 COLLECTION",
    content: "MULTI SIDED | WINTER 2022 COLLECTION",
    clear: true,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid02keKCEvKxHMLh6yDR3Cxdpvtxy2niHzPm7S2Sdk3Jnw9sjjdAidAqenWgwE9BLeGLl",
    title: "TRANSITION | FALL WINTER 2022",
    img: "https://pos.nvncdn.net/be3159-662/album/20221104_9OqlhdeK9yNcr5jf0jfEMObH.png",
    alt: "TRANSITION | FALL WINTER 2022",
    content: "TRANSITION | FALL WINTER 2022",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid02nAf8Xt2v4TzLuTMuFLraqtsfupE3UJ8bhoaLZPYUJpiQAqvDoMLTF8kpCPfix52Fl",
    title: "SMART CASUAL | AUTUMN OUTFIT IDEAS",
    img: "https://pos.nvncdn.net/be3159-662/album/20221022_Ww8P4cBIPCRUTtkraUpXfBp2.png",
    alt: "SMART CASUAL | AUTUMN OUTFIT IDEAS",
    content: "SMART CASUAL | AUTUMN OUTFIT IDEAS",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid0383b7ND8Z2178Ci1v4W3TWadc2Hr7J7kLfk7audqwhQTDJEYUvFVQTgvMfQZUnEY4l",
    title: "HYPE BOYS | AUTUMN COLLECTION 2022",
    img: "https://pos.nvncdn.net/be3159-662/album/20221022_L5gzn0wfcr5bALtHJ9Mo6bTH.png",
    alt: "HYPE BOYS | AUTUMN COLLECTION 2022",
    content: "HYPE BOYS | AUTUMN COLLECTION 2022",
    clear: false,
  },
  {
    href: "https://www.facebook.com/Krik.vn/posts/pfbid02kugcCGcEFenAXnMiDVoNDk4Dexst9GPtDACsSDPSxafsR1KLyPAQw1Yxu7W5gjXfl",
    title: "CÔNG SỞ ",
    img: "https://pos.nvncdn.net/be3159-662/album/20220913_DSY89u761jo5eWAApS0zPNnA.png",
    alt: "CÔNG SỞ ",
    content: "CÔNG SỞ 'TRẺ' COLLECTION",
    clear: true,
  },
];
const listNews = [
  {
    url: dynamicUrlProduct("GRAND OPENING - KRIK 132 CẦU GIẤY"),
    titleContent: "GRAND OPENING - KRIK 132 CẦU GIẤY",
    img: "https://pos.nvncdn.net/be3159-662/art/20220414_APrkMfdUjfaw80IG7MP02a0o.jpg",
    alt: "GRAND OPENING - KRIK 132 CẦU GIẤY",
    description:
      " GRAND OPENING | KRIK 132 CẦU GIẤYSự kiện khai trương cửa hàng đầu tiên mang tên KRIK tại 132 Cầu Giấy trong những ngày vừa qua đã diễn ra thành công rực rỡ và ấn tượng.KRIK xin gửi lời cảm ơn chân thành nhất tới các vị khách hàng yêu quý, gia đình và bạn bè đã tới tham dự sự kiện và ủng hộ Thương hiệu.Chúng mình sẽ cố gắng phát triển thật lớn mạnh và nâng tầm dịch vụ để làm hài lòng tất cả khách hàng cũng như khẳng định vị trí Thương hiệu tại thị trường thời trang sắp tới.------------------Hệ thống cửa hàng tại Hà Nội:- 132 Cầu Giấy- 344 Cầu Giấy- 338 Nguyễn Trãi- 23 Chùa Bộc- 209 Bạch Mai- 189 Phố Nhổn- 183 Trần CungHotline: 0982.022.969",
  },
  {
    url: dynamicUrlProduct("TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK"),
    titleContent: "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK",
    img: "https://pos.nvncdn.net/be3159-662/art/20220222_fwFqi3XqntfiXKRAq1mVC8Lj.png",
    alt: "TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIK",
    description:
      " TONY4MEN CHÍNH THỨC ĐỔI TÊN THÀNH KRIKBạn thân mến,9 năm là cả một chặng đường dài đối với một Thương hiệu thời trang, để có một chỗ đứng vững trãi, cùng những thành công nhất định trên thị trường, Tony4men đã phải vượt qua rất nhiều khó khăn và thách thức.Nếu như bạn đã gắn bó cùng chúng mình trong suốt thời gian qua với sự hài lòng và tin tưởng, thì KRIK hứa hẹn sẽ đem tới cho bạn nhiều điều bất ngờ về sự mới mẻ, bùng nổ sáng tạo, và đặc biệt là những trải nghiệm tuyệt vời về sản phẩm cũng như chất lượng dịch vụ trong thời gian tới.Một phiên bản mới với sự hoàn hảo về mọi khía cạnh đến từ KRIK. Không đơn giản chỉ là thương hiệu thời trang, KRIK còn mang tầm nhìn và sứ mệnh mong muốn trở thành người bạn đồng hành của phái mạnh trong bất cứ hoàn cảnh nào.Cùng chúng mình đón chờ và trải nghiệm những điều tuyệt vời đang nằm ở phía trước nhé ^^",
  },
  {
    url: dynamicUrlProduct("Cách thức đặt hàng"),
    titleContent: "Cách thức đặt hàng",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_tWsOvjK7GrEPGtWl7LHitQPc.png",
    alt: "Cách thức đặt hàng",
    description:
      "Cách thức đặt hàngĐặt hàng qua Hotline: Gọi trực tiếp đến sđt: 0982.022.969 để được nhân viên tư vấn hỗ trợ nhanh nhất về sản phẩm và dịch vụ.Đặt hàng trên FB: Gửi ảnh hoặc mã sp mà mình quan tâm đến Page KRIK (m.me/krik.vn). Nhân viên tư vấn sẽ trả lời nhanh nhất khi có thể. Liên hệ trực tiếp số hotline: 0982.022.969 để được hỗ trợ nhanh nhất.Đặt hàng trên Web:B1: Click vào sản phẩm muốn đặt hàngB2: Chọn màu sắc, size và số lượng muốn đặt rồi Click [Mua Ngay]B3: Click vào [ Tiến hành đặt hàng ] để chuyển sang giao diện điền thông tin giao hàng hoặc có thể click vào [ Xem chi tiết giỏ hàng ] để xem lại giỏ hàng của mình.B4: Điền thông tin vào form đặt hàng: Họ tên, số điện thoại, email, địa chỉB5: Chọn phương thức thanh toán: COD (thanh toán tại nhà)B6: Hoàn tất đơn hàngKRIK sẽ xác nhận đơn hàng bằng cách gọi điện. Vui lòng nghe máy để chúng tôi có thể lên đơn thành công giúp bạn.",
  },
  {
    url: dynamicUrlProduct("Chính sách thành viên"),
    titleContent: "Chính sách thành viên",
    img: "https://pos.nvncdn.net/be3159-662/art/20191216_5ldS53UxoZILDHMoTXdsk99T.png",
    alt: "Chính sách thành viên",
    description:
      "Chính sách thành viênMEMBER CARD: Tổng giá trị hóa đơn đã mua từ 0-3tr được tích 3% trên tổng giá trị hóa đơn.VIP CARD: Tổng giá trị hóa đơn đã mua từ 3-6tr được tích 5% trên tổng giá trị hóa đơnSUPERVIP CARD: Tổng giá trị hóa đơn đã mua >6tr được tích 8% trên tổng giá trị hóa đơn.⇒ Khách hàng mua hàng (tại cửa hàng) trong tuần sinh nhật ( trước và sau ngày sinh nhật 3 ngày ) được giảm 10% trên tổng hóa đơn.",
  },
  {
    url: dynamicUrlProduct("Chính sách giao hàng"),
    titleContent: "Chính sách giao hàng",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_qxrfJ3E8NcHVwRABBl5dSRdT.png",
    alt: "Chính sách giao hàng",
    description:
      "Chính sách giao hàngNhận ship COD toàn quốc, thanh toán khi nhận hàng.Đơn nội thành nhận trong ngày, với đơn ngoại thành nhận hàng sau 1-2 ngày. Những đơn hàng đi tỉnh tùy thuộc vào vị trí địa lý xa hay gần mà thời gian giao hàng có thể dao động từ 3-5 ngày. Liên hệ hotline: 0982.022.969 để biết thông tin nhanh nhất về đơn hàng. Miễn phí vận chuyển cho đơn hàng trên 1 triệu Hỗ trợ phí vận chuyển cho đơn hàng trên 500k (tối đa 30k)",
  },
  {
    url: dynamicUrlProduct("Chính sách đổi trả hàng"),
    titleContent: "Chính sách đổi trả hàng",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_Hm7q4j114CB308j4q47JCO0P.png",
    alt: "Chính sách đổi trả hàng",
    description:
      "Chính sách đổi trả hàngĐể giúp khách hàng có những trải nghiệm mua sắm tốt nhất & luôn cảm thấy hài lòng với sự lựa chọn của mình, KRIK mang đến chính sách đổi trả dễ dàng và thuận tiện1. ĐIỀU KIỆN ĐỔI HÀNG Khách hàng còn giữ hóa đơn mua hàng, có để lại thông tin khách hàng khi mua hàngThời gian đổi hàng trong vòng 05 ngày kể từ ngày mua hàng Hàng đổi phải còn nguyên tem, nhãn mác, không có mùi lạ, chưa qua sử dụng hay giặt làKhông hỗ trợ đổi với những sản phẩm sale và các đơn hàng mua bằng Voucher Sản phẩm sale khi mua vào ngày sinh nhật, sản phẩm sale dưới 30% chỉ hỗ trợ đổi size, đổi màu, sản phẩm sale lớn hơn 30% sẽ không hỗ trợ đổiChỉ hỗ trợ đổi hàng tối đa 1 lầnSản phẩm đồ lót, phụ kiện không hỗ trợ đổi Không hỗ trợ đổi với sản phẩm giặt chung với sản phẩm khác gây phai màu, đổi màu, có dấu hiệu sửa chữa. Sản phẩm hỏng hoặc rách do tác nhân bên ngoàiTrường hợp shop gửi sai sản phẩm, hàng hóa có lỗi chủ quan do nhà sản xuất KRIK sẽ chịu toàn bộ chi phí đổi hàng hai chiềuTrường hợp khách hận hàng không ưng ý sản phẩm muốn đổi size, đổi mẫu thì phải chịu hoàn toàn chi phí đổi hàng và thanh toán cho bên hãng vận chuyển 2. GIÁ TRỊ ĐỔI HÀNGKRIK chỉ hỗ trợ đổi hàng sang sản phẩm mới có giá trị ngang hoặc lớn hơn giá trị sản phẩm đổi3. ĐỊA ĐIỂM ĐỔI HÀNGKhách hàng có thể đổi hàng ở bất cứ cửa hàng nào trên toàn hệ thốngĐối với khách hàng muốn đổi hàng online vui lòng gửi hàng về địa chỉ ghi trên đơn hàng (phần người gửi hàng) hoặc liên hệ hotline: 0982.022.969 để được hướng dẫn quy trình làm đổi hàng. KRIK sẽ gửi lại sản phẩm mới cho quý khách sau khi nhận được sản phẩm trả lại. 4. TRẢ HÀNGKRIK không hỗ trợ trả hàng để hoàn tiền trong bất cứ trường hợp nào.",
  },
  {
    url: dynamicUrlProduct("Hình thức thanh toán"),
    titleContent: "Hình thức thanh toán",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_3FxpZKlj7dQphImapDSRI9En.png",
    alt: "Hình thức thanh toán",
    description:
      "Hình thức thanh toán1. Các hình thức thanh toán- Thanh toán khi nhận hàng: Tiền Mặt- Thanh toán qua hình thức quẹt thẻ (thẻ nội địa, thẻ VISA/MASTERCARD được phát hành bởi các Ngân hàng thương mại Việt Nam)- Chuyển khoản qua ứng dụng Mobile Banking do các ngân hàng cung cấp. 2. Chi tiết hình thức thanh toán- Tiền Mặt: Thu tiền mặt khi khách hàng nhận hàng (Tiền Việt Nam Đồng thật và đủ tiêu chuẩn lưu thông theo quy định của Ngân hàng Nhà nước Việt Nam)- Thanh toán qua ứng dụng Mobile Banking do các ngân hàng cung cấp qua hình thức chuyển khoản - Thanh toán qua hình thức quẹt thẻ (thẻ nội địa, thẻ VISA/MASTERCARD được phát hành bởi các Ngân hàng thương mại Việt Nam) bằng máy Pos tại điểm bán. 3. Quy định áp dụng thanh toánCó thể áp dụng cho tất cả các đơn hàng đặt hàng trên website krik.vn",
  },
  {
    url: dynamicUrlProduct("Chính sách bảo mật"),
    titleContent: "Chính sách bảo mật",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_IGWJwoxjlFHFiWJ0qNV5hS3l.png",
    alt: "Chính sách bảo mật",
    description:
      "Chính sách bảo mậtMục đích: Nhằm tôn trọng sự riêng tư, bảo vệ thông tin cá nhân và thông tin thanh toán của KHÁCH HÀNG cũng như thuận tiện cho việc chăm sóc khách hàng của chúng tôi.Thông tin bao gồm: Họ tên, số điện thoại, email, địa chỉCam kết: Chúng tôi cam kết bảo mật hoàn toàn thông tin của khách hàng. Có các biện pháp thích hợp về kỹ thuật và an ninh để ngăn chặn việc truy cập , sử dụng trái phép thông tin khách hàng.Sử dụng thông tin KH:Giao hàng đúng địa chỉ mà khách hàng cung cấpCung cấp thông tin về sản phẩm cũng như dịch vụ mà khách hàng cầTiếp thị, quảng cáo về các chương trình khuyến mãi hay ưu đãi về sản phẩm mà chúng tôi bánXử lý thắc mắc, khiếu nại của khách hàng về sản phẩm, dịch vụKhông sử dụng thông tin khách hàng ngoài mục đích xác nhận đơn hàng và liên hệ có liên quan đến giao dịchThời gian lưu trữ thông tin: Thông tin cá nhân của khách hàng sẽ được lưu trữ cho đến khi có yêu cầu ban quản trị hủy bỏ. Còn lại trong mọi trường hợp thông tin cá nhân của khách hàng sẽ được bảo mật trên hệ thống của Krik.Những người hoặc tổ chức có thể được tiếp cận với thông tin KH:Nhân viên trong hệ thống công tyĐối tác kết hợp với công ty có ký hợp đồng thỏa thuận về việc sử dụng thông tin Khách Hàng ( có thể một phần hay toàn bộ thông tin, tùy vào điều khoản trong hợp đồng )Địa chỉ của đơn vị thu thập và quản lý thông tin:CÔNG TY TNHH TIME MANĐịa chỉ: Số 344 Cầu giấy, Phường Dịch Vọng, Quận Cầu Giấy, Thành Phố Hà NộiMã số doanh nghiệp: 0108901419 do Sở kế hoạch và đầu tư thành phố Hà Nội cấp ngày 17/09/2019Điện thoại: 0982.022.969Email: timeman.vn@gmail.comPhương thức và công cụ để người tiêu dùng tiếp cận và chỉnh sửa dữ liệu:KHÁCH HÀNG có quyền tự kiểm tra, chỉnh sửa hoặc hủy bỏ thông tin cá nhân của mình bằng cách yêu cầu trực tiếp nhân viên thu ngân tại cửa hàng hoặc liên hệ với ban quản trị của công ty. KHÁCH HÀNG có quyền gửi khiếu nại về nội dung bảo mật thông tin đề nghị liên hệ Ban quản trị công ty. Khi tiếp nhận những phản hồi này, chúng tôi sẽ xác nhận lại thông tin, trường hợp đúng như phản ánh của KH tùy theo mức độ, chúng tôi sẽ có những biện pháp xử lý kịp thời.",
  },
  {
    url: dynamicUrlProduct("Chính sách khiếu nại"),
    titleContent: "Chính sách khiếu nại",
    img: "https://pos.nvncdn.net/be3159-662/art/20200512_s1BtEt6xqvIQtOQQHgcoGvls.png",
    alt: "Chính sách khiếu nại",
    description:
      "Chính sách xử lý khiếu nạiTrong trường hợp có bất kỳ thắc mắc hay khiếu nại về sản phẩm, dịch vụ, quý khách vui lòng liên hệ hotline: 09159.88888 Khiếu nại về việc giao sản phẩm, thái độ của nhân viên giao hàng, đổi/trả sản phẩm... Khách hàng có thể liên hệ với bộ phận chăm sóc khách hàng (CSKH) theo số hotline: 0982.022.969. Bộ phận CSKH sẽ tiếp nhận và phản hồi lại cho khách hàng trong thời gian sớm nhất Website: https://krik.vn Facebook: https://www.facebook.com/Tony4men Email: timeman.vn@gmail.com",
  },
  {
    url: dynamicUrlProduct("Chính sách kiểm hàng"),
    titleContent: "Chính sách kiểm hàng",
    img: "https://pos.nvncdn.net/be3159-662/art/20220305_EkHoAlJE8OXZVdNAUgpm7sUW.png",
    alt: "Chính sách kiểm hàng",
    description:
      "Chính sách kiểm hàngNhằm đáp ứng nhu cầu và bảo vệ tối đa quyền lợi khách hàng khi mua sản phẩm của KRIK. Chúng tôi đã triển khai chính sách hỗ trợ việc xem và kiểm tra hàng hóa khi giao hàng. Khách hàng khi nhận được hàng từ nhân viên vận chuyển có thể mở niêm phong cói hàng của chúng tôi để đồng kiểm tra hàng hóa với nhân viên vận chuyển.Lưu ý:  KRIK hỗ trợ cho khách hàng xem hàng nhưng vui lòng không thử.Trong trường hợp nhân viên vận chuyển yêu cầu quý khách ký vào biên bản xác nhạn khách hàng đã nhận đủ và nguyên vẹn tất cả sản phẩm (biên bản đồng kiểm). KRIK khuyến khích quý khách sử dụng tối đa quyền lợi trên trước khi ký xác nhận để được hỗ trợ tốt nhất trong mọi tình huống. Nếu phát sinh yêu cầu đổi trả quý khách vui lòng liên hệ hotline: 0982.022.969 để được hỗ trợ nhanh nhất.",
  },
  {
    url: dynamicUrlProduct("Sinh Nhật 7 Tuổi"),
    titleContent: "Sinh Nhật 7 Tuổi",
    img: "https://pos.nvncdn.net/be3159-662/art/20200519_VZo5w0FlWgEdWebONflm46ld.jpg",
    alt: "Sinh Nhật 7 Tuổi",
    description:
      "🎁𝗛𝗔𝗣𝗣𝗬 𝟳𝗧𝗛 𝗧𝗢𝗡𝗬𝟰𝗠𝗘𝗡 𝗕𝗜𝗥𝗧𝗛𝗗𝗔𝗬🎁‼TONY4MEN chính thức tròn 7 năm hình thành và phát triển. Đó là một chặng đường không hẳn dài cũng không quá ngắn mà đó là quãng thời gian vừa đủ để chúng mình nỗ lực định hình phong cách thời trang cho đa số các bạn trẻ Việt Nam.⏰ Cũng trong thời gian đó, TONY4MEN đã trở thành địa chỉ quen thuộc của những tín đồ yêu thời trang khắp cả nước.Từ 1 cửa hàng nhỏ, chúng mình đã mở rộng và phát triển thành chuỗi hệ thống gồm 6 cửa hàng tại nội thành Hà Nội, luôn mang đến những phong cách mới mẻ, bắt kịp trend nhất đến với các bạn trẻ🛒 Nhân dịp sinh nhật lần thứ 7 này TONY4MEN xin dành tặng chương trình SALE TƯNG BỪNG - ĐỒNG GIÁ 49K như một lời tri ân đến khách hàng đã tin tưởng và ủng hộ chúng mình trong suốt thời gian vừa qua..",
  },
  {
    url: dynamicUrlProduct("Phối đồ với sơ mi trắng sao cho hợp ??"),
    titleContent: "Phối đồ với sơ mi trắng sao cho hợp ??",
    img: "https://pos.nvncdn.net/be3159-662/art/20200531_OPvKJJkDXgoWqdT9KvNlzfnF.jpg",
    alt: "Phối đồ với sơ mi trắng sao cho hợp ??",
    description:
      "Chỉ cần biết cách phối đồ với áo sơ mi trắng nam bạn đã có thể tạo ra những set đồ “cực chất”!Sự thật là…90% phụ nữ thừa nhận họ bị “đốn gục” hoàn toàn trước hình ảnh chàng trai mặc áo sơ mi trắng. Quả thật, sơ mi trắng chính là “vũ khí không lời” giúp phái mạnh toát lên nét quyến rũ chết người. Vậy áo sơ mi trắng nên mix cùng Items nào để “bộ cánh” nhìn thời thượng hơn? Có rất nhiều cách “hay ho” để phối đồ với áo sơ mi trắng nam, hãy để TONY4MEN “bật mí” cho bạn nhé !",
  },
];
const listShipping = [
  {
    selected: true,
    rowspan: false,
    isImg: true,
    title: "Ninja Van",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877508_499.png",
    content: "Giao tiêu chuẩn 22k",
    description: "2 - 4 ngày",
    priceShip: 22000,
  },
  {
    selected: false,
    rowspan: true,
    isImg: true,
    title: "Ahamove",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877609_356.png",
    content: "Siêu tốc trong 1h - Ứng tiền mặt",
    description: "Siêu tốc trong 1h",
    priceShip: 32000,
  },
  {
    selected: false,
    isImg: false,
    title: "Ahamove",
    content: "Siêu rẻ trong 2h - Ứng tiền mặt",
    description: "Siêu rẻ trong 2h",
    priceShip: 26000,
  },
  {
    selected: false,
    rowspan: true,
    isImg: true,
    title: "Grab Express",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877449_119.png",
    content: "Siêu rẻ 4h - Ứng tiền mặt",
    description: "Giao hàng trong 4 giờ, từ 9h đến 16h",
    priceShip: 23000,
  },
  {
    selected: false,
    isImg: false,
    title: "Grab Express",
    content: "Siêu tốc - Ứng tiền mặt",
    description: "Giao siêu tốc",
    priceShip: 33000,
  },
  {
    selected: false,
    rowspan: false,
    isImg: true,
    title: "Giaohangnhanh",
    src: "https://carrier.nvncdn.net/carrier/carr_1668675827_477.png",
    content: "Giao nội tỉnh",
    description: "2 ngày",
    priceShip: 18000,
  },
];
const ngoaiThanh = [
  {
    selected: true,
    rowspan: false,
    isImg: true,
    title: "Ninja Van",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877508_499.png",
    content: "Giao tiêu chuẩn 22k",
    description: "2 - 4 ngày",
    priceShip: 22000,
  },
  {
    selected: false,
    rowspan: true,
    isImg: true,
    title: "Ahamove",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877609_356.png",
    content: "Siêu tốc trong 1h - Ứng tiền mặt",
    description: "Siêu tốc trong 1h",
    priceShip: 40000,
  },
  {
    selected: false,
    isImg: false,
    title: "Ahamove",
    content: "Siêu rẻ trong 2h - Ứng tiền mặt",
    description: "Siêu rẻ trong 2h",
    priceShip: 36000,
  },
  {
    selected: false,
    rowspan: true,
    isImg: true,
    title: "Grab Express",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877449_119.png",
    content: "Siêu rẻ 4h - Ứng tiền mặt",
    description: "Giao hàng trong 4 giờ, từ 9h đến 16h",
    priceShip: 33000,
  },
  {
    selected: false,
    isImg: false,
    title: "Grab Express",
    content: "Siêu tốc - Ứng tiền mặt",
    description: "Giao siêu tốc",
    priceShip: 40000,
  },
  {
    selected: false,
    rowspan: false,
    isImg: true,
    title: "Giaohangnhanh",
    src: "https://carrier.nvncdn.net/carrier/carr_1668675827_477.png",
    content: "Giao nội tỉnh",
    description: "2 ngày",
    priceShip: 23000,
  },
];
const tinhLe = [
  {
    selected: true,
    rowspan: false,
    isImg: true,
    title: "Ninja Van",
    src: "https://carrier.nvncdn.net/carrier/carr_1664877508_499.png",
    content: "Giao tiêu chuẩn 22k",
    description: "2 - 5 ngày",
    priceShip: 22000,
  },

  {
    selected: false,
    rowspan: false,
    isImg: true,
    title: "Giaohangnhanh",
    src: "https://carrier.nvncdn.net/carrier/carr_1668675827_477.png",
    content: "Tiêu chuẩn NV",
    description: "2-3 ngày",
    priceShip: 30000,
  },
];
const methodPayments = [
  {
    description: "Thanh toán qua thẻ thanh toán, ứng dụng ngân hàng VNPAY",
    img: "payment-icon--16",
    selected: false,
    choose: false,
  },
  {
    description: "Thanh toán qua mã QR - VNPAY",
    img: "payment-icon--19",
    selected: false,
    choose: false,
  },
  {
    description: "Thanh toán qua Ví MoMo",
    img: "payment-icon--21",
    selected: false,
    choose: false,
  },
  {
    description: "Thanh toán khi nhận hàng (COD)",
    img: "payment-icon--4",
    selected: false,
    choose: true,
  },
];
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
  listAlbums,
  listAlbumTinTuc,
  listNewProductHomePages,
  product,
  dataChooseCity,
  dataChooseQuan,
  dataChoosePhuong,
  listNews,
  listShipping,
  methodPayments,
  ngoaiThanh,
  tinhLe,
  productLIst
};
