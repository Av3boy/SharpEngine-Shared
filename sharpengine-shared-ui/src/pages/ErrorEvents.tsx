import React, { createContext, useCallback, useContext, useMemo, useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';

export type ErrorSeverity = 'error' | 'warning' | 'info' | 'success';

export type ErrorEvent = {
  id: string;
  timestamp: number;
  message: string;
  severity: ErrorSeverity;
  source?: string;
  data?: unknown;
};

type ErrorEventsContextValue = {
  errors: ErrorEvent[];
  latest: ErrorEvent | null;
  publish: (event: Omit<ErrorEvent, 'id' | 'timestamp'>) => void;
  clear: (id?: string) => void;
};

const ErrorEventsContext = createContext<ErrorEventsContextValue | undefined>(undefined);

const MAX_EVENTS = 100;

export const ErrorEventsProvider: React.FC<React.PropsWithChildren> = ({ children }) => {
  const [events, setEvents] = useState<ErrorEvent[]>([]);

  const publish = useCallback((event: Omit<ErrorEvent, 'id' | 'timestamp'>) => {
    setEvents((prev) => {
      const next: ErrorEvent = {
        ...event,
        id: `${Date.now()}-${Math.random().toString(36).slice(2, 8)}`,
        timestamp: Date.now(),
      };
      const list = [...prev, next];
      return list.length > MAX_EVENTS ? list.slice(list.length - MAX_EVENTS) : list;
    });
  }, []);

  const clear = useCallback((id?: string) => {
    setEvents((prev) => {
      if (!id) {
        // Clear latest
        return prev.slice(0, -1);
      }
      return prev.filter((e) => e.id !== id);
    });
  }, []);

  const latest = useMemo(() => (events.length ? events[events.length - 1] : null), [events]);

  const value = useMemo<ErrorEventsContextValue>(() => ({ errors: events, latest, publish, clear }), [events, latest, publish, clear]);

  return <ErrorEventsContext.Provider value={value}>{children}</ErrorEventsContext.Provider>;
};

export const useErrorEvents = (): ErrorEventsContextValue => {
  const ctx = useContext(ErrorEventsContext);
  if (!ctx) {
    throw new Error('useErrorEvents must be used within an ErrorEventsProvider');
  }
  return ctx;
};

// Auto-clear latest error on route changes. Must be rendered inside a Router.
export const ErrorEventsAutoClear: React.FC = () => {
  const { clear } = useErrorEvents();
  const location = useLocation();

  useEffect(() => {
    clear();
  }, [location.pathname, clear]);

  return null;
};
