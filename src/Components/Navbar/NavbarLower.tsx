import React from "react";
import { Link } from "react-router-dom";
import { HoveredLink, Menu, MenuItem } from "../ui/navbar-menu";
import { cn } from "../utils/cn";

const NavbarLower: React.FC<{ className?: string, active: string | null, setActive: (item: string | null) => void }> = ({ className, active, setActive }) => {
  return (
    <div className={cn("fixed top-14 inset-x-0 max-w-2xl mx-auto z-50", className)}>
      <Menu setActive={setActive}>
        <MenuItem setActive={setActive} active={active} item="Categories">
          <div className="flex flex-col space-y-4 text-sm">
            <HoveredLink href="/clothing">Clothing</HoveredLink>
            <HoveredLink href="/electronics">Electronics</HoveredLink>
            <HoveredLink href="/kitchenware">Kitchen Ware</HoveredLink>
            <HoveredLink href="/furniture">Furniture</HoveredLink>
          </div>
        </MenuItem>
        <MenuItem setActive={setActive} active={active} item="Pricing">
          <div className="flex flex-col space-y-4 text-sm">
            <HoveredLink href="/hobby">Hobby</HoveredLink>
            <HoveredLink href="/individual">Individual</HoveredLink>
            <HoveredLink href="/team">Team</HoveredLink>
            <HoveredLink href="/enterprise">Enterprise</HoveredLink>
          </div>
        </MenuItem>
        <Link to="/profile">
          <MenuItem setActive={setActive} active={active} item="Profile">
            <div className="flex flex-col space-y-4 text-sm">
              <HoveredLink href="/profile">My Profile</HoveredLink>
            </div>
          </MenuItem>
        </Link>  
        <Link to="/login">
          <MenuItem setActive={setActive} active={active} item="Login/Signup">
            Login/Signup
          </MenuItem>
        </Link>
      </Menu>
    </div>
  );
};

export default NavbarLower;
