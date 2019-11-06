/* eslint-disable */
import qs from 'qs'
import axios from 'axios'
let _api = {}
_api._domain = ''
_api._getDomain = () => {
  return _api._domain
}
_api._setDomain = ($domain) => {
  _api._domain = $domain
}
_api._request = (method, url, body, queryParameters, form, config) => {
  method = method.toLowerCase()
  let keys = Object.keys(queryParameters)
  if (keys.length > 0) {
    url = url + '?' + qs.stringify(queryParameters)
  }
  switch (method) {
    case 'get':
      return axios.get(url, config)
    case 'head':
      return axios.head(url, config)
    case 'delete':
      return axios.delete(url, config)
    case 'post':
      return axios.post(url, body, config)
    case 'put':
      return axios.put(url, body, config)
    case 'patch':
      return axios.patch(url, body, config)
  }
}
/************************************************************
 * 
 ************************************************************/
/**
 * 
 * request: Get
 * url: GetURL
 * method: Get_TYPE
 * raw_url: Get_RAW_URL
 * @param id - id
 */
_api.Get = (parameters = {}) => {
  const domain = parameters.$domain ? parameters.$domain : _api._getDomain()
  let config = parameters.$config || {}
  let path = '/api/Home/{id}'
  let body
  let queryParameters = {}
  let headers = {}
  let form = {}
  path = path.replace('{id}', `${parameters['id']}`)
  if (parameters['id'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: id'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach((parameterName) => {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  config.headers = {
    ...config.heaers,
    ...headers
  }
  return _api._request('get', domain + path, body, queryParameters, form, config)
}
_api.Get_RAW_URL = () => {
  return '/api/Home/{id}'
}
_api.Get_TYPE = () => {
  return 'get'
}
_api.GetURL = (parameters = {}) => {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : _api._getDomain()
  let path = '/api/Home/{id}'
  path = path.replace('{id}', `${parameters['id']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach((parameterName) => {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * 
 * request: Post
 * url: PostURL
 * method: Post_TYPE
 * raw_url: Post_RAW_URL
 * @param files - files
 */
_api.Post = (parameters = {}) => {
  const domain = parameters.$domain ? parameters.$domain : _api._getDomain()
  let config = parameters.$config || {}
  let path = '/api/Home/UploadFiles'
  let body
  let queryParameters = {}
  let headers = {}
  let form = {}
  if (parameters['files'] !== undefined) {
    form['files'] = parameters['files']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach((parameterName) => {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  config.headers = {
    ...config.heaers,
    ...headers
  }
  return _api._request('post', domain + path, body, queryParameters, form, config)
}
_api.Post_RAW_URL = () => {
  return '/api/Home/UploadFiles'
}
_api.Post_TYPE = () => {
  return 'post'
}
_api.PostURL = (parameters = {}) => {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : _api._getDomain()
  let path = '/api/Home/UploadFiles'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach((parameterName) => {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
export default _api
