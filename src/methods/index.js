import unorm from "unorm"; // Import thư viện unorm
function dynamicUrlProduct(namePro){
  if(namePro != null) {
    let newStr = namePro.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/\s+/g, "-");
    return `${newStr}`
  }
    return namePro;
}
function convertNameSingin(name) {
     if (name == null) return;
     const words = name.trim().toLowerCase().split(" ");
      const newWords = words.map((word) => {
      const firstLetter = word.slice(0, 1).toUpperCase(); // Lấy ký tự đầu tiên và viết hoa
      const restLetters = word.slice(1); // Lấy các ký tự còn lại
      const normalized = unorm.nfc(firstLetter + restLetters); // Thêm dấu vào các chữ cái

      return normalized;
    });
    const newString = newWords.join(" ");
    return newString;
  }
 function validateEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
  }
  function validatePhoneNumber(phoneNumber) {
    let pattern = /^0\d{9}$/;
    return pattern.test(phoneNumber);
  }
  function splitStringByDot(str) {
    if(str == null || str == "" || str == undefined) return;
    
    return str.split(/\.+/).slice(0, -1).map(item => item.replace(/\n/g, ''));
  }
              /**
         * Thực hiện xử lý dữ liệu DateOfBirth trả về từ api hiển thị ra bảng
         **  Author: Đinh Công Trứ(30/10/2022)
         */
         function handleDOB(dob) {
          if (dob) {
              dob = new Date(dob);
              let date = dob.getDate(dob);
              let month = dob.getMonth(dob) + 1;
              let year = dob.getFullYear(dob);

              return `${date < 10 ? "0" + date : date}/${
                  month < 10 ? "0" + month : month
              }/${year}`;
          }
          return false;
      }
      /**------------------------------------------
      *Hàm chuyển chuỗi camelCase sang snake_case
      @param {String} key-chuỗi đầu vào
      *Author: quyetkaito (07/04/2022)
      --------------------------------------------*/
      function camelToUnderscore(key) {
          var result = key.replace(/([A-Z])/g, " $1");
          result = result.trim();
          return result.split(" ").join("_").toLowerCase();
      }


export{dynamicUrlProduct,convertNameSingin,validateEmail,validatePhoneNumber,splitStringByDot,handleDOB,camelToUnderscore}