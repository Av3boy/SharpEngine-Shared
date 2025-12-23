import { useAuth0, User } from '@auth0/auth0-react';
import PermIdentityIcon from '@mui/icons-material/PermIdentity';

export function ProfileHeader() {
  const { user } = useAuth0();

  return (
    <div style={{backgroundImage: "linear-gradient(to right, oklch(0.546 0.245 262.881) 0%, oklch(0.558 0.288 302.321) 100%)"}} className="text-black p-8">
      <div className="max-w-6xl mx-auto flex items-center gap-6">
        <div className="w-24 h-24 rounded-full bg-white/20 flex items-center justify-center">
          {user?.picture && <img src={user.picture} alt="Profile" className="w-24 h-24 rounded-full object-cover" />}
        </div>
        <div>
          <h1 className="text-white">{user?.name}</h1>
          <p className="text-white/80">Member since December 2024</p>
        </div>
      </div>
    </div>
  );
}
