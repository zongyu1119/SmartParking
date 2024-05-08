import JSEncrypt from 'jsencrypt'
import jsrsasign from 'jsrsasign'

/**
 * RSA密钥生成
 * @param {*} length
 * @returns
 */
export function RsaKey(length = 256) {
  var rsaKeypair = jsrsasign.KEYUTIL.generateKeypair('RSA', length)
  // 获取公钥
  let PUBLIC = jsrsasign.KEYUTIL.getPEM(rsaKeypair.prvKeyObj)
  // 获取私钥
  let PRIVATE = jsrsasign.KEYUTIL.getPEM(rsaKeypair.prvKeyObj, 'PKCS8PRV')

  return {
    publicKey: PUBLIC,
    privateKey: PRIVATE
  }
}
/**
 * RSA加密
 */
export function Encode(text, publicKey) {
  // 初始化加密类实例
  var encrypt = new JSEncrypt()

  // 设置公钥
  encrypt.setPublicKey('-----BEGIN PUBLIC KEY-----\n' + publicKey + '\n-----END PUBLIC KEY-----')

  // 加密
  var encrypt_text = encrypt.encrypt(text)
  console.log('encrypted: ', encrypt_text)
  return encrypt_text
}
/**
 * Rsa解密
 */
export function Decode(text, privateKey) {
  // 初始化解密类实例
  var decrypt = new JSEncrypt()

  // 设置私钥
  decrypt.setPrivateKey(
    '-----BEGIN RSA PRIVATE KEY-----\n' + privateKey + '\n-----END RSA PRIVATE KEY-----'
  )

  // 解密
  var decrypt_text = decrypt.decrypt(text)
  console.log('decrypted: ', decrypt_text)
  return decrypt_text
}
