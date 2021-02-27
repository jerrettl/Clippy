import React from 'react';
import './AboutContent.css';
import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Link,
  List,
  ListItem,
  ListItemText
} from '@material-ui/core';

export default function AboutContent() {
    return (
      <div class="AboutContent">
        <Card className="AboutContentCard">
          <CardHeader title="Product Vision" />
          <CardContent>
            For internet users who find themselves having a difficult time organizing and discovering resources on the Web that sparks their interest, we introduce Clippy. Clippy is a social bookmarking service designed for users to explore and manage resources on the Internet. Users can immerse themselves in their own distraction-free space curated by them or explore resources gathered by others in the community. Unlike many other social bookmarking services, such as Pocket, Clippy is currently open source for anyone to adapt or use for themselves.
          </CardContent>
        </Card>
        <Card className="AboutContentCard">
          <CardHeader title="Team Members" />
          <CardContent>
            <List>
              <Link underline="none" href="https://github.com/BlackOutDevelops">
                <ListItem button="true">
                  <ListItemText>
                    Joshua Frazer (@BlackOutDevelops)
                  </ListItemText>
                </ListItem>
              </Link>
              <Link underline="none" href="https://github.com/jordynhayden">
                <ListItem button="true">
                  <ListItemText>
                    Jordyn Hayden (@jordynhayden)
                  </ListItemText>
                </ListItem>
              </Link>
              <Link underline="none" href="https://github.com/jerrettl">
                <ListItem button="true">
                  <ListItemText>
                    Jerrett Longworth (@jerrettl)
                  </ListItemText>
                </ListItem>
              </Link>
              <Link underline="none" href="https://github.com/diegoro1">
                <ListItem button="true">
                  <ListItemText>
                    Diego Rodrigues (@diegoro1)
                  </ListItemText>
                </ListItem>
              </Link>
              <Link underline="none" href="https://github.com/jaerom">
                <ListItem button="true">
                  <ListItemText>
                    Jaeivan Romero (@jaerom)
                  </ListItemText>
                </ListItem>
              </Link>
            </List>
          </CardContent>
        </Card>
        <Card className="AboutContentCard">
          <CardHeader title="Source Code" />
          <CardContent>
            Clippy is open source! Feel free to check out the source code for our entire project at our GitHub.
            <CardActions>
              <Button variant="outlined" href="https://github.com/Clippy5/Clippy">Source Code</Button>
            </CardActions>
          </CardContent>
        </Card>
        <Card className="AboutContentCard">
          <CardHeader title="How to Run" />
        </Card>
      </div>
    )
}
