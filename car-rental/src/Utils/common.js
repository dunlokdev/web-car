export function GetCurrency(price) {
  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(price);
}

export function decode(str) {
  const txt = new DOMParser().parseFromString(str, "text/html");
  return txt.documentElement.textContent;
}
