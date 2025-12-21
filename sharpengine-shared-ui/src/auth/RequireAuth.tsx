import { Navigate, Outlet } from "react-router-dom";

export function RequireAuth({ isAllowed }: { isAllowed: boolean }) {
  if (!isAllowed) {
    return <Navigate to="/error?statusCode=403&errorMessage=Forbidden" replace />;
  }

  return <Outlet />;
}
