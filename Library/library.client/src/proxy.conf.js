const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7173';

const PROXY_CONFIG = [
  {
    context: [
      "/auth/login",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/auth/register",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/getbooks",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/getbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/addbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/editbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/removebook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/checkoutbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/returnbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/book/reviewbook",
    ],
    target,
    secure: false
  },
  {
    context: [
      "/images/*",
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
