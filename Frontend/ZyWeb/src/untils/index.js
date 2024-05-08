export const setUserInfo = (userInfo) => {
  localStorage.setItem('user', JSON.stringify(userInfo))
}
export const getUserInfo = () => {
  const user = localStorage.getItem('user')
  return JSON.parse(user)
}
