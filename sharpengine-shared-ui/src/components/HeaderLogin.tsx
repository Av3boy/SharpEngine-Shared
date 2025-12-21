import { User } from "@auth0/auth0-react";

export type HeaderLoginProps = {
  onProfileClicked: () => void;
  loginWithRedirect: () => void | Promise<void>;
  logout: () => void | Promise<void>;
  isAuthenticated: boolean;
  user?: User;
  useWhiteText?: boolean;
};

export function HeaderLogin({ onProfileClicked, loginWithRedirect, logout, isAuthenticated, user, useWhiteText }: HeaderLoginProps) {

  function loginUser(e: React.MouseEvent<HTMLButtonElement>) {
    e.preventDefault(); 
    loginWithRedirect();
  }

  function logoutUser(e: React.MouseEvent<HTMLButtonElement>) {
    e.preventDefault();
    logout();
  }

  const colorClass = useWhiteText ? 'text-white/80 hover:text-white' : 'text-gray-800 hover:text-black';
  const profileBorder = useWhiteText ? '1px solid rgba(255,255,255,0.2)' : '1px solid rgba(0,0,0,0.2)';
  const iconFill = useWhiteText ? '#e3e3e3' : '#333333';

  if (isAuthenticated)
    return (
      <div className="flex items-center gap-4" style={{ justifyContent: 'space-between', gap: '16px' }}>
        <button
          className={`${colorClass} transition-colors flex items-center`}
          onClick={(e) => {
            e.preventDefault();
            onProfileClicked();
          }}
          aria-label={user?.name ? `Open profile for ${user.name}` : 'Open profile'}
        >
          {user?.picture ? (
            <img
              src={user.picture}
              alt={user?.name ?? 'Profile picture'}
              className="rounded-full"
              style={{ width: 32, height: 32, objectFit: 'cover', border: profileBorder, cursor: 'pointer' }}
            />
          ) : (
            <span className={`${colorClass} transition-colors`}>Profile</span>
          )}
        </button>
        <button
          className={`${colorClass} transition-colors`}
          style={{ cursor: 'pointer' }}
          onClick={(e) => logoutUser(e)}
          aria-label="Logout"
        >
          <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="24px" viewBox="0 0 24 24" width="24px" fill={iconFill}>
            <g>
              <path d="M0,0h24v24H0V0z" fill="none" />
            </g>
            <g>
              <path d="M17,8l-1.41,1.41L17.17,11H9v2h8.17l-1.58,1.58L17,16l4-4L17,8z M5,5h7V3H5C3.9,3,3,3.9,3,5v14c0,1.1,0.9,2,2,2h7v-2H5V5z" />
            </g>
          </svg>
        </button>
      </div>
    );

  return (
    <button
      className={`${colorClass} transition-colors`}
      style={{ alignSelf: 'start', cursor: 'pointer' }}
      onClick={(e) => loginUser(e)}
    >
      Login
    </button>
  );
}