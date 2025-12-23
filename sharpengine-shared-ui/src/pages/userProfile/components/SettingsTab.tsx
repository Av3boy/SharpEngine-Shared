import { useAuth0 } from '@auth0/auth0-react';
import { useState } from 'react';

export function SettingsTab() {
  const { user } = useAuth0();

  const [subscribeToReleases, setSubscribeToReleases] = useState(true);
  const [subscribeToPreReleases, setSubscribeToPreReleases] = useState(false);
  const [notifyOnAssetPurchase, setNotifyOnAssetPurchase] = useState(false);
  

  return (
    <div className="max-w-6xl mx-auto p-8" style={{paddingTop: '0'}}>
      <div className="flex items-center gap-3 mb-6">
        {/*<Settings className="w-6 h-6 text-blue-600" />*/}
        <h2 className="text-2xl font-semibold">Account Settings</h2>
      </div>
      
      <div className="max-w-2xl space-y-6">
        {/* Email Section */}
        <div className="border border-gray-200 rounded-lg p-6">
          <div className="flex items-center gap-2 mb-4">
            {/*<Mail className="w-5 h-5 text-gray-600" />*/}
            <h3>Email Address</h3>
          </div>
          
          <input
            type="email"
            value={user?.email || ''}
            placeholder='your@email.com'
            className="w-full px-4 py-2 border border-gray-300 rounded-lg bg-gray-50 text-gray-600 cursor-not-allowed"
          />
          <p className="text-sm text-gray-500 mt-2">
            Your email address cannot be changed
          </p>
        </div>

        {/* Notification Preferences Section */}
        <div className="border border-gray-200 rounded-lg p-6">
          <div className="flex items-center gap-2 mb-4">
            {/*<Bell className="w-5 h-5 text-gray-600" />*/}
            <h3>Notification Preferences</h3>
          </div>
          
          <div className="space-y-4">
            <label className="flex items-center gap-3 cursor-pointer group">
              <input
                type="checkbox"
                checked={subscribeToReleases}
                onChange={(e) => setSubscribeToReleases(e.target.checked)}
                className="w-5 h-5 text-blue-600 border-gray-300 rounded focus:ring-2 focus:ring-blue-500 cursor-pointer"
              />
              <div>
                <div className="group-hover:text-blue-600 transition-colors">
                  Subscribe to release notifications
                </div>
                <p className="text-sm text-gray-500">
                  Get notified when new features and updates are released
                </p>
              </div>
            </label>

            <label className="flex items-center gap-3 cursor-pointer group">
              <input
                type="checkbox"
                checked={subscribeToPreReleases}
                onChange={(e) => setSubscribeToPreReleases(e.target.checked)}
                className="w-5 h-5 text-blue-600 border-gray-300 rounded focus:ring-2 focus:ring-blue-500 cursor-pointer"
              />
              <div>
                <div className="group-hover:text-blue-600 transition-colors">
                  Subscribe to pre-release notifications
                </div>
                <p className="text-sm text-gray-500">
                  Be the first to know about upcoming features and beta releases
                </p>
              </div>
            </label>

            <label className="flex items-center gap-3 cursor-pointer group">
              <input
                type="checkbox"
                checked={notifyOnAssetPurchase}
                onChange={(e) => setNotifyOnAssetPurchase(e.target.checked)}
                className="w-5 h-5 text-blue-600 border-gray-300 rounded focus:ring-2 focus:ring-blue-500 cursor-pointer"
              />
              <div>
                <div className="group-hover:text-blue-600 transition-colors">
                  Notify me when my assets are purchased
                </div>
                <p className="text-sm text-gray-500">
                  Receive an email or in-app notification when someone buys one of your assets
                </p>
              </div>
            </label>
          </div>
        </div>
      </div>
    </div>
  );
}
