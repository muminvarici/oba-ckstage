import { createBackendModule } from '@backstage/backend-plugin-api';
import {
  authProvidersExtensionPoint,
  createOAuthProviderFactory,
} from '@backstage/plugin-auth-node';
import {
  stringifyEntityRef,
  DEFAULT_NAMESPACE,
} from '@backstage/catalog-model';
import { githubAuthenticator } from '@backstage/plugin-auth-backend-module-github-provider';

export default createBackendModule({
  pluginId: 'auth',
  moduleId: 'github-custom-resolver',
  register(reg) {
    reg.registerInit({
      deps: {
        providers: authProvidersExtensionPoint,
      },
      async init({ providers }) {
        providers.registerProvider({
          providerId: 'github',
          factory: createOAuthProviderFactory({
            authenticator: githubAuthenticator,
            async signInResolver(info, ctx) {
              const { profile } = info;
              console.log('GitHub profile:', profile);
              // Use GitHub username for matching catalog entities
              // GitHub usernames are stable and unique
              const username =
                (profile as any).username || profile.email?.split('@')[0];

              if (!username) {
                throw new Error('GitHub profile does not contain a username');
              }

              // Create a user entity reference from the GitHub username (lowercase)
              const userEntityRef = stringifyEntityRef({
                kind: 'User',
                name: username.toLowerCase(),
                namespace: DEFAULT_NAMESPACE,
              });

              return ctx.issueToken({
                claims: {
                  sub: userEntityRef,
                  ent: [userEntityRef],
                },
              });
            },
          }),
        });
      },
    });
  },
});
