import  {useState} from 'react'
import {Card, Container, Divider, Grid, GridColumn, GridRow, Header, Icon, Input} from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import './App.css'

interface ToDoModel {
    id: number,
    task: string,
    isCompleted: boolean,
    createdDate: Date
}

const App = () => {
    const [list, setList] = useState<ToDoModel[]>([]);
    const [text, setText] = useState('');
    const addToList = () => {
        setList([...list, {
            id: Date.now(),
            createdDate: new Date(),
            isCompleted: false,
            task: text
        }])

        setText('')
    }

    const deleteToDo = (id: number) => {
        setList(list.filter(x => x.id != id))
    }

    const doneToDo = (id: number) => {
        setList(list.map(function (x) {
            if (x.id == id)
                x.isCompleted = !x.isCompleted;

            return x;
        }))
    }

    return (
        <Container>
            <Header as='h1' textAlign={'center'}>ToDos</Header>
            <Card.Group>
                {
                    list.map((item, index) =>
                        <Card onDoubleClick={() => doneToDo(item.id)} style={{padding: 25}} fluid
                              color={index % 2 == 0 ? 'green' : 'orange'}>
                            <Grid>
                                <GridRow>
                                    <GridColumn width={'10'}>
                                        <Header style={{textDecoration: item.isCompleted ? 'line-through' : undefined}}
                                                as='h3'>{item.task}</Header>
                                    </GridColumn>
                                    <GridColumn verticalAlign={'middle'} width={'5'}>
                                        <Header as='h5'>{item.createdDate.toISOString()}</Header>
                                    </GridColumn>
                                    <GridColumn verticalAlign={'middle'} width={'1'}>
                                        <Icon onClick={() => deleteToDo(item.id)} color={'red'} size={'large'}
                                              name={'trash'}/>
                                    </GridColumn>
                                </GridRow>
                            </Grid>
                        </Card>
                    )
                }
            </Card.Group>

            <Divider/>

            <Input
                action={{
                    color: 'orange',
                    labelPosition: 'right',
                    icon: 'add',
                    content: 'Add',
                    onClick: addToList
                }}
                fluid
                onChange={(e) => setText(e.target.value)}
                value={text}
            />
        </Container>
    )
}

export default App