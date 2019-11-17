/* Auth service
Settings are set here for authorization
This has to correspond with 'Client.cs' in the Identity Server
 */

import { UserManager, WebStorageStateStore, User } from 'oidc-client';

export default class AuthService {
    private userManager: UserManager;

    constructor() {
        const STS_DOMAIN: string = 'https://localhost:6103';

        const settings: any = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: STS_DOMAIN,
            client_id: 'bookstore',
            client_secret: 'secret',
            redirect_uri: 'http://localhost:8080/callback.html', //http://localhost:8080/callback.html',
            automaticSilentRenew: true, 
            silent_redirect_uri: 'http://localhost:8080/silent-renew.html',
            response_type: 'code',
            scope: 'openid profile email bookstore',
            post_logout_redirect_uri: 'http://localhost:8080/',
            filterProtocolClaims: true,
            audience: 'bookstore',
        };

        this.userManager = new UserManager(settings);
    }

    public getUser(): Promise<User> {
        console.log('getuser usermanager: '+this.userManager.getUser());
        return this.userManager.getUser();
    }

    public login(): Promise<void> {
        console.log('login in authservicets')
        return this.userManager.signinRedirect();
    }

    public logout(): Promise<void> {
        return this.userManager.signoutRedirect();
    }

    public getAccessToken(): Promise<string> {
        return this.userManager.getUser().then((data: any) => {
            return data.access_token;
        });
    }

    public getIdToken(): Promise<string>{
        return this.userManager.getUser().then((data: any) => {
            return data.id_token;
        })
    }
}