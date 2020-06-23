import Oidc from 'oidc-client';

var mgr = new Oidc.UserManager({
    authority: 'https://localhost:6103',
    client_id: 'bookstore', //ok
    redirect_uri: 'https://localhost:5001/callback', //ok
    response_type: 'id_token',
    scope: 'openid profile email',
    post_logout_redirect_uri: 'https://localhost:5001/',
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage }),
})

export default mgr;