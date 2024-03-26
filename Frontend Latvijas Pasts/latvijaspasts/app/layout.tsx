import Layout, { Content, Footer, Header } from "antd/es/layout/layout";
import "./globals.css";
import {Menu} from "antd";
import Link from "next/link";


const item = [
  { key: "home", label: <Link href={"/"}>Home</Link> },
  { key: "CV", label: <Link href={"/cv"}>Cv</Link> }
];

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHeight: "100vh"}}>
          <Header>
            <Menu
            theme="dark"
            mode="horizontal"
            items={item}
            style={{flex: 1, minWidth: 0}}
            />
            </Header>
            <Content style={{padding:"0 48px"}}>{children}</Content>
            <Footer style={{ textAlign: "center"}}>
              Latvijas Pasts 2024 Created by Me
            </Footer>
          </Layout>
      </body>
    </html>
  );
}
